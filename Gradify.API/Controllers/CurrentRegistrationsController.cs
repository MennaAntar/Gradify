using Gradify.Core.DTO;
using Gradify.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gradify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentRegistrationsController : ControllerBase
    {
        private readonly ICurrentRegistrationRepository _CurrentRegistrationRepository;

        public CurrentRegistrationsController(ICurrentRegistrationRepository CurrentRegistrationRepository)
        {
            _CurrentRegistrationRepository = CurrentRegistrationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegistrationDTO dto)
        {
            try
            {
                await _CurrentRegistrationRepository.AddAsync(dto);
                return Ok(new { Message = "Registration created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RegistrationDTO dto)
        {
            try
            {
                await _CurrentRegistrationRepository.UpdateAsync(id, dto);
                return Ok(new { Message = "Registration updated successfully" });
            }
            catch (KeyNotFoundException knf)
            {
                return NotFound(knf.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
