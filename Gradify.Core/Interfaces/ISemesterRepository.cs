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
    public interface ISemesterRepository
    {
        Task<IEnumerable<SemesterResponse>> GetAllAsync();
        Task<IEnumerable<SemesterResponse>> SearchAsync(string SemesterName);
        Task AddAsync(SemesterDTO semester);
        Task UpdateAsync(SemesterDTO semester);
        Task DeleteAsync(string SemesterName);
    }
}
