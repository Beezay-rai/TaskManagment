using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticateController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult SignUp()
        {
            return Ok();
        }

    }
}
