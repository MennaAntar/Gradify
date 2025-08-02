using Gradify.Core.DTO;
using Gradify.Core.Models;
using Gradify.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Interfaces
{
    public interface ISemesterCourseSettingsRepository
    {
        Task<IEnumerable<SemesterCourseSettingsResponse>> GetAllAsync();
        Task<IEnumerable<SemesterCourseSettingsResponse>> SearchAsync(string keyword);
        Task AddAsync(SemesterCourseSettingsDto SettingsDto);
        Task UpdateAsync(SemesterCourseSettingsDto SettingsDto);
        Task DeleteAsync(string course, string semester);
    }
}
