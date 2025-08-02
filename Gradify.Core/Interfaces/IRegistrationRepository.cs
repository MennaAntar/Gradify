using Gradify.Core.DTO;
using Gradify.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<IEnumerable<RegistrationResponse>> GetAllAsync();
        Task<IEnumerable<RegistrationResponse>> SearchAsync(string keyword);
        Task DeleteAsync(int id);
    }
}
