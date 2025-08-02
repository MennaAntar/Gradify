using Gradify.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Interfaces
{
    public interface ICurrentRegistrationRepository
    {
        Task AddAsync(RegistrationDTO registrationDto);
        Task UpdateAsync(int id, RegistrationDTO registrationDto);
    }
}
