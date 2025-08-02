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
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseResponse>> GetAllAsync()
        {
            var courses = await _context.Courses.ToListAsync();

            return courses.Select(c => new CourseResponse
            {
                Code = c.Code,
                Name = c.Name,
                CreditHrs = c.CreditHrs
            });
        }

        public async Task<IEnumerable<CourseResponse>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Search keyword cannot be empty.");

            var courses = await _context.Courses
                .Where(c =>
                    c.Code.Contains(keyword) ||
                    c.Name.Contains(keyword))
                .ToListAsync();

            return courses.Select(c => new CourseResponse
            {
                Code = c.Code,
                Name = c.Name,
                CreditHrs = c.CreditHrs
            });
        }

        public async Task AddAsync(CourseDTO courseDto)
        {
            if (courseDto == null)
                throw new ArgumentNullException(nameof(courseDto));

            var course = new Course
            {
                Code = courseDto.Code,
                Name = courseDto.Name,
                CreditHrs = courseDto.CreditHrs
            };

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CourseDTO courseDto)
        {
            var course = await _context.Courses.FindAsync(courseDto.Code);
            if (course == null)
                throw new KeyNotFoundException($"Course with Code '{courseDto.Code}' not found.");

            course.Name = courseDto.Name;
            course.CreditHrs = courseDto.CreditHrs;

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var course = await _context.Courses.FindAsync(code);
            if (course == null)
                throw new KeyNotFoundException($"Course with Code '{code}' not found.");

            course.State=GeneralState.Deleted;
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}
