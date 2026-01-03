using EMS.API.Dtos.Departments;
using EMS.API.Services.DepartmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] DepartmentCreateDto dto) 
        { 
            var result = await _service.AddAsync(dto);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] DepartmentUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                if (!result)
                {
                    return NotFound("Department not found");
                }
                return Ok("Department deleted successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Department not found");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}
