using Gradify.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gradify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var students = await _studentRepository.GetAllAsync();
                return Ok(new
                {
                    Message = "Students retrieved successfully.",
                    Data = students
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
                var results = await _studentRepository.SearchAsync(keyword);
                return Ok(new
                {
                    Message = "Students retrieved successfully.",
                    Data = results
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}