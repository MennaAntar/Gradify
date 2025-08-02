using Gradify.Core.DTO;
using Gradify.Core.Interfaces;
using Gradify.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gradify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var courses = await _courseRepository.GetAllAsync();
                return Ok(new
                {
                    Message = "Courses retrieved successfully.",
                    Data = courses
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            try
            {
                var results = await _courseRepository.SearchAsync(keyword);
                return Ok(new
                {
                    Message = "Courses retrieved successfully.",
                    Data = results
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseDTO courseDto)
        {
            try
            {
                await _courseRepository.AddAsync(courseDto);
                return Ok(new
                {
                    Message = "Course added successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(CourseDTO courseDto)
        {
            try
            {
                await _courseRepository.UpdateAsync(courseDto);
                return Ok(new
                {
                    Message = "Course updated successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            try
            {
                await _courseRepository.DeleteAsync(code);
                return Ok(new
                {
                    Message = "Course deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}