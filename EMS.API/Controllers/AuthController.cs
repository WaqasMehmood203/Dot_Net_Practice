using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
            //-> Login, Signup, ForgotPassword, ResetPassword, GetRefreshToken

        }
        [HttpPost("Login")]

        public void Login()
        {
        }
        [HttpPost("Signup")]
        public void Signup()
        {
        }
        [HttpPost("ForgotPassword")]
        public void ForgotPassword()
        {
        }

        [HttpPost("ResetPassword")]
        public void ResetPassword()
        {
        }
        [HttpGet("GetRefreshToken")]
        public List<string> GetRefreshToken()
        {
            return new List<string> { "Tokken1", "Tokken2", "Tokken3" };
        }
    }
}
