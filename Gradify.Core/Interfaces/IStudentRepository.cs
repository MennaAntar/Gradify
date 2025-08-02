using Gradify.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentResponse>> GetAllAsync();
        Task<IEnumerable<StudentResponse>> SearchAsync(string keyword);
    }
}
