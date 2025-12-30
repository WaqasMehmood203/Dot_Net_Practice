using EMS.API.DbContexts;
using EMS.API.Entities.DB4_Entities;
using EMS.API.Services.TeacherService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public readonly ITeacherService _teacherservice;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherservice = teacherService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            var result = await _teacherservice.AddTeacherAsync(teacher);
            return Ok(result);
        }

    }
}
