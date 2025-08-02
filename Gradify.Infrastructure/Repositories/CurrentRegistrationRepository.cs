using Gradify.Core.DTO;
using Gradify.Core.Interfaces;
using Gradify.Core.Models;
using Gradify.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Infrastructure.Repositories
{
    public class CurrentRegistrationRepository:ICurrentRegistrationRepository
    {
        private readonly AppDbContext _context;

        public CurrentRegistrationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RegistrationDTO registrationDto)
        {
            var entity = new Registration
            {
                SemesterName = registrationDto.SemesterName,
                StudentId = registrationDto.StudentId,
                CourseCode = registrationDto.CourseCode,
            };

            entity.RegistrationDate=DateTime.Now;
            entity.FinalMarks = 0;
            entity.IsAbsentFinal = false;

            await _context.Registrations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, RegistrationDTO registrationDto)
        {
            var entity = await _context.Registrations.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Registration not found");

            entity.SemesterName = registrationDto.SemesterName;
            entity.StudentId = registrationDto.StudentId;
            entity.CourseCode = registrationDto.CourseCode;

            _context.Registrations.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
