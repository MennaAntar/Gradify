using Gradify.Core.DTO;
using Gradify.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Gradify.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SemesterCourseSettingsController : ControllerBase
    {
        private readonly ISemesterCourseSettingsRepository _repository;

        public SemesterCourseSettingsController(ISemesterCourseSettingsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/SemesterCourseSettings
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(new
            {
                Message = "Get Successfully",
                Data = result
            });
        }

        // GET: api/SemesterCourseSettings/search?keyword=...
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var result = await _repository.SearchAsync(keyword);
            if (!result.Any()) return NotFound("No matching records found");
            return Ok(new { 
                Message="Get Successfully",
                Data=result
            });
        }

        // POST: api/SemesterCourseSettings
        [HttpPost]
        public async Task<IActionResult> Create(SemesterCourseSettingsDto dto)
        {
            await _repository.AddAsync(dto);
            return Ok(new
            {
                Message = "Create Successfully"
            });
        }

        // PUT: api/SemesterCourseSettings
        [HttpPut]
        public async Task<IActionResult> Update(SemesterCourseSettingsDto dto)
        {
            try
            {
                await _repository.UpdateAsync(dto);
                return Ok(new
                {
                    Message = "Updated Successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/SemesterCourseSettings/{courseCode}/{semesterName}
        [HttpDelete("{courseCode}/{semesterName}")]
        public async Task<IActionResult> Delete(string courseCode, string semesterName)
        {
            try
            {
                await _repository.DeleteAsync(courseCode, semesterName);
                return Ok(new
                {
                    Message = "Deleted Successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
