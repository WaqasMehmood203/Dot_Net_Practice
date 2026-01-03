using EMS.API.Dtos.Country;
using EMS.API.Services.CountryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _service;
        public CountryController(ICountryService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CountryCreateDto dto)
        { 
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(Guid Id, [FromBody] CountryUpdateDto dto)
        {
            var result = await _service.UpdateAsync(Id,dto);
            if(result == null)
            {
                return NotFound("Country Not Found");
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            try
            {
                var result = await _service.DeleteAsync(Id);
                if (!result)
                {
                    return NotFound("Country Not Found");
                }
                return Ok("Country Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var result = await _service.GetByIdAsync(Id);
            if(result == null)
            {
                return NotFound("Country Not Found");
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
