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
    public class SemesterRepository : ISemesterRepository
    {
        private readonly AppDbContext _context;

        public SemesterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SemesterResponse>> GetAllAsync()
        {
            var semesters = await _context.Semesters.ToListAsync();

            return semesters.Select(s => new SemesterResponse
            {
                SemesterName = s.SemesterName,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            });
        }

        public async Task<IEnumerable<SemesterResponse>> SearchAsync(string SemesterName)
        {
            if (string.IsNullOrWhiteSpace(SemesterName))
                throw new ArgumentException("Semester name cannot be empty.");

            var semesters= await _context.Semesters
                .Where(s => s.SemesterName.Contains(SemesterName))
                .ToListAsync();

            return semesters.Select(s => new SemesterResponse
            {
                SemesterName = s.SemesterName,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            });
        }

        public async Task AddAsync(SemesterDTO semesterDto)
        {
            if (semesterDto == null)
                throw new ArgumentNullException(nameof(semesterDto));

            var semester = new Semester
            {
                SemesterName = semesterDto.SemesterName,
                StartDate = semesterDto.StartDate,
                EndDate = semesterDto.EndDate
            };

            await _context.Semesters.AddAsync(semester);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SemesterDTO semesterDto)
        {
            if (semesterDto == null)
                throw new ArgumentNullException(nameof(semesterDto));

            var semester = await _context.Semesters.FindAsync(semesterDto.SemesterName);

            if (semester == null)
                throw new KeyNotFoundException($"Semester '{semesterDto.SemesterName}' was not found.");

            // تحديث الخصائص
            semester.SemesterName = semesterDto.SemesterName;
            semester.StartDate = semesterDto.StartDate;
            semester.EndDate = semesterDto.EndDate;

            _context.Semesters.Update(semester);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string SemesterName)
        {
            var semester = await _context.Semesters.FindAsync(SemesterName);
            if (semester != null)
            {
                semester.State = GeneralState.Deleted;
                _context.Semesters.Update(semester);
                await _context.SaveChangesAsync();
            }
        }
    }

}
