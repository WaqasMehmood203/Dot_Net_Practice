using EMS.API.Dtos.Cities;
using EMS.API.Services.CityServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _service;
        public CityController(ICityService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCity(CityCreateDto dto)
        {
            var result = await _service.AddAsync(dto);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCity(Guid Id, CityUpdateDto dto)
        {
            var result = await _service.UpdateAsync(Id, dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCity(Guid Id)
        {
            try
            {
                var result = await _service.DeleteAsync(Id);
                if (!result)
                {
                    return NotFound();
                }
                return Ok("City Deleted Successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _service.GetByIdAsync(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Getall()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}
