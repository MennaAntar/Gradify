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
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentResponse>> GetAllAsync()
        {
            var students = await _context.Students.ToListAsync();
            return students.Select(s => new StudentResponse
            {
                Id = s.Id,
                Name = s.Name,
                CGPA = s.CGPA,
                NetHrs = s.NetHrs,
                CurrentPoints = s.CurrentPoints,
                LastCalculationDate = s.LastCalculationDate,
                Status = s.Status.ToString()
            });
        }

        public async Task<IEnumerable<StudentResponse>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Search keyword cannot be empty.");

            var students = await _context.Students
                .Where(s =>
                    s.Id.ToString().Contains(keyword) ||
                    s.Name.Contains(keyword))
                .ToListAsync();

            return students.Select(s => new StudentResponse
            {
                Id = s.Id,
                Name = s.Name,
                CGPA = s.CGPA,
                NetHrs = s.NetHrs,
                CurrentPoints = s.CurrentPoints,
                LastCalculationDate = s.LastCalculationDate,
                Status = s.Status.ToString()
            });
        }
    }

}
