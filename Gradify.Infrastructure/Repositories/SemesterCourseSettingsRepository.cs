using Gradify.Core.DTO;
using Gradify.Core.Enums;
using Gradify.Core.Interfaces;
using Gradify.Core.Models;
using Gradify.Core.Responses;
using Gradify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Infrastructure.Repositories
{
    public class SemesterCourseSettingsRepository : ISemesterCourseSettingsRepository
    {
        private readonly AppDbContext _context;

        public SemesterCourseSettingsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SemesterCourseSettingsResponse>> GetAllAsync()
        {
            return await _context.SemesterCourseSettings
                .Include(s => s.Course)
                .Include(s => s.Semester)
                .Select(s => new SemesterCourseSettingsResponse
                {
                    CourseCode = s.CourseCode,
                    SemesterName = s.SemesterName,
                    CourseWorkValue = s.CourseWorkValue,
                    FinalValue = s.FinalValue
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SemesterCourseSettingsResponse>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Search keyword cannot be empty.");

            return await _context.SemesterCourseSettings
                .Include(s => s.Course)
                .Include(s => s.Semester)
                .Where(s =>
                    s.CourseCode.ToLower().Contains(keyword) ||
                    s.SemesterName.ToLower().Contains(keyword))
                .Select(s => new SemesterCourseSettingsResponse
                {
                    CourseCode = s.CourseCode,
                    SemesterName = s.SemesterName,
                    CourseWorkValue = s.CourseWorkValue,
                    FinalValue = s.FinalValue
                })
                .ToListAsync();
        }

        public async Task AddAsync(SemesterCourseSettingsDto dto)
        {
            var entity = new SemesterCourseSettings
            {
                CourseCode = dto.CourseCode,
                SemesterName = dto.SemesterName,
                CourseWorkValue = dto.CourseWorkValue,
                FinalValue = dto.FinalValue
            };

            await _context.SemesterCourseSettings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SemesterCourseSettingsDto dto)
        {
            var entity = await _context.SemesterCourseSettings
                .FirstOrDefaultAsync(s => s.CourseCode == dto.CourseCode && s.SemesterName == dto.SemesterName);

            if (entity == null) throw new KeyNotFoundException("Semester course settings not found");

            entity.CourseWorkValue = dto.CourseWorkValue;
            entity.FinalValue = dto.FinalValue;

            _context.SemesterCourseSettings.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string course, string semester)
        {
            var entity = await _context.SemesterCourseSettings
                .FirstOrDefaultAsync(s => s.CourseCode == course && s.SemesterName == semester);

            if (entity == null) throw new KeyNotFoundException("Semester course settings not found");

            entity.State=GeneralState.Deleted;
            _context.SemesterCourseSettings.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
