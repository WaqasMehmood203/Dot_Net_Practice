using EMS.API.Entities;
using EMS.API.Entities.DB2_Entities;
using EMS.API.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Route("Employee")]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeservice;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeservice = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            var result = await _employeeservice.AddEmployeeAsync(employee);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
                return BadRequest("ID mismatch");

            var updated = await _employeeservice.UpdateEmployeeAsync(id, employee);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }
        [HttpDelete]
        public async Task<bool> DeleteEmployee(Guid id)
        {
            try
            {
                var employee = await _employeeservice.DeleteEmployeeAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var result = await _employeeservice.GetEmployeeByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("getallEmployee")]
        public async Task<IActionResult> GetallEmployee()
        {
            return Ok(await _employeeservice.GetAllEmployeeAsync());
        }
    }
}
