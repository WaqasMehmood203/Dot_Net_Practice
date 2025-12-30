using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Route("Dashboard")]
    public class DashboardController : ControllerBase
    {
        [HttpGet("Summary")]
        public int Summary(int Totaluser, int Totalemployees)
        {
            return Totaluser + Totalemployees;
        }
    }
}
