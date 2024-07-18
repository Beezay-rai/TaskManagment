using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Utilities;
using TaskManagementApplication.Features.Authenticate.Commands;
using TaskManagementApplication.Models;

namespace TaskManagementApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUtility _utility;
        public AuthenticateController(IMediator mediator,IUtility utility)
        {
            _mediator = mediator;
            _utility = utility;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            var response = await _mediator.Send(new LoginCommand() { LoginModel = model });
            if (response.Status)
            {

                response.Data["Token"] = _utility.GenerateToken(response.Data);
            }
            
          

            return Ok(response);
        }
        [HttpPost]
        public IActionResult SignUp(SignUpModel model)
        {
            var response = _mediator.Send(new SignUpCommand() { SignUpModel =model});
            return Ok();
        }

    }
}
