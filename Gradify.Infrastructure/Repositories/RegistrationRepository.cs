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
    public class RegistrationRepository:IRegistrationRepository
    {
        private readonly AppDbContext _context;

        public RegistrationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistrationResponse>> GetAllAsync()
        {
            return await _context.RegistrationArchives
                .Select(r => new RegistrationResponse
                {
                    SemesterName = r.SemesterName,
                    StudentId = r.StudentId,
                    CourseCode = r.CourseCode,
                    RegistrationDate = r.RegistrationDate,
                    FinalMarks = r.FinalMarks,
                    IsAbsentFinal = r.IsAbsentFinal,
                    Grade = r.Grade
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<RegistrationResponse>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Search keyword cannot be empty.");

            return await _context.RegistrationArchives
                .Where(c =>
                    c.StudentId.ToString().Contains(keyword) ||
                    c.CourseCode.Contains(keyword) ||
                    c.SemesterName.Contains(keyword))
                .Select(r => new RegistrationResponse
                {
                    SemesterName = r.SemesterName,
                    StudentId = r.StudentId,
                    CourseCode = r.CourseCode,
                    RegistrationDate = r.RegistrationDate,
                    FinalMarks = r.FinalMarks,
                    IsAbsentFinal = r.IsAbsentFinal,
                    Grade = r.Grade
                })
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.RegistrationArchives.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Registration not found");

            entity.State=GeneralState.Deleted;
            _context.RegistrationArchives.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
