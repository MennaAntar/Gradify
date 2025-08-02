using Gradify.Core.DTO;
using Gradify.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gradify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamRepository _examRepository;

        public ExamsController(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var exams = await _examRepository.GetAllAsync();
                return Ok(new { Message = "Exams retrieved successfully", Data = exams });
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
                var results = await _examRepository.SearchAsync(keyword);
                return Ok(new { Message = "Exams retrieved successfully", Data = results });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamDTO examDto)
        {
            try
            {
                await _examRepository.AddAsync(examDto);
                return Ok(new { Message = "Exam added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ExamDTO examDto)
        {
            try
            {
                await _examRepository.UpdateAsync(id, examDto);
                return Ok(new { Message = "Exam updated successfully" });
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _examRepository.DeleteAsync(id);
                return Ok(new { Message = "Exam deleted successfully" });
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