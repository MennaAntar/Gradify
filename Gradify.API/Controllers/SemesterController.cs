using Gradify.Core.DTO;
using Gradify.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gradify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterRepository _semesterRepository;

        public SemesterController(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var semesters = await _semesterRepository.GetAllAsync();
                return Ok(new
                {
                    Message = "Semesters retrieved successfully.",
                    Data = semesters
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Search(string name)
        {
            try
            {
                var semester = await _semesterRepository.SearchAsync(name);
                if (semester == null)
                    return NotFound("Semester not found.");

                return Ok(new
                {
                    Message = "Semester retrieved successfully.",
                    Data = semester
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SemesterDTO semester)
        {
            try
            {
                await _semesterRepository.AddAsync(semester);
                return CreatedAtAction(nameof(Search), new { name = semester.SemesterName }, semester);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{name}")]
        public async Task<IActionResult> Update(string name, SemesterDTO semester)
        {
            try
            {
                await _semesterRepository.UpdateAsync(semester);
                return Ok(new
                {
                    Message = "Semester updated successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            try
            {
                await _semesterRepository.DeleteAsync(name);
                return Ok(new
                {
                    Message = "Semester deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}