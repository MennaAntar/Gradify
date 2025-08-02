using Gradify.Core.DTO;
using Gradify.Core.Enums;
using Gradify.Core.Interfaces;
using Gradify.Core.Models;
using Gradify.Core.Responses;
using Gradify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Gradify.Infrastructure.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _context;

        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExamResponse>> GetAllAsync()
        {
            return await _context.Exams
                .Select(e => new ExamResponse
                {
                    Name = e.Name,
                    DisplayMarks = e.DisplayMarks,
                    RealMarks = e.RealMarks,
                    IsAbsent = e.IsAbsent,
                    IsSame = e.IsSame
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ExamResponse>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Search keyword cannot be empty.");

            return await _context.Exams
                .Where(e => e.Name.ToLower().Contains(keyword))
                .Select(e => new ExamResponse
                {
                    Name = e.Name,
                    DisplayMarks = e.DisplayMarks,
                    RealMarks = e.RealMarks,
                    IsAbsent = e.IsAbsent,
                    IsSame = e.IsSame,
                })
                .ToListAsync();
        }

        public async Task AddAsync(ExamDTO examDto)
        {
            var exam = new Exam
            {
                Name = examDto.Name,
                DisplayMarks = examDto.DisplayMarks,
                RealMarks = examDto.RealMarks,
                IsSame = examDto.IsSame,
                IsAbsent = examDto.RealMarks == 0
            };

            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ExamDTO examDto)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
                throw new KeyNotFoundException("Exam not found");

            exam.Name = examDto.Name;
            exam.DisplayMarks = examDto.DisplayMarks;
            exam.RealMarks = examDto.RealMarks;
            exam.IsSame = examDto.IsSame;
            exam.IsAbsent = examDto.RealMarks == 0;

            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
                throw new KeyNotFoundException("Exam not found");

            exam.State=GeneralState.Deleted;
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }
    }
}