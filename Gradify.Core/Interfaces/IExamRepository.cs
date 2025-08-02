using Gradify.Core.DTO;
using Gradify.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Interfaces
{
    public interface IExamRepository
    {
        Task<IEnumerable<ExamResponse>> GetAllAsync();
        Task<IEnumerable<ExamResponse>> SearchAsync(string keyword);
        Task AddAsync(ExamDTO examDto);
        Task UpdateAsync(int id, ExamDTO examDto);
        Task DeleteAsync(int id);
    }
}
