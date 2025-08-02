using Gradify.Core.DTO;
using Gradify.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseResponse>> GetAllAsync();
        Task<IEnumerable<CourseResponse>> SearchAsync(string keyword);
        Task AddAsync(CourseDTO courseDto);
        Task UpdateAsync(CourseDTO courseDto);
        Task DeleteAsync(string code);
    }
}
