using MediatR;
using TaskManagementApplication.Common;
using TaskManagementApplication.Exception;
using TaskManagementApplication.Interfaces;
using TaskManagementApplication.Models;

namespace TaskManagementApplication.Features.Authenticate.Commands
{
    public class LoginCommand : IRequest<(int httpCode,object response)>
    {
        public LoginModel LoginModel { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, (int httpCode, object response)>
    {
        private readonly IAuthenticateRepository _repo;

        public LoginCommandHandler(IAuthenticateRepository repo)
        {
            _repo = repo;
        }


        public async Task<(int httpCode, object response)> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginCommandValidator();
            var check =validator.Validate(request.LoginModel);
            if (!check.IsValid)
            {

                var errorResponse = new ErrorResponseModel()
                {
                    Status = false,
                    Message ="Login failure",
                    ErrorDescription = check.Errors.Select(x=>x.ErrorMessage).ToList()
                };
                return (400, errorResponse);
            }

            var response = await _repo.Login(request.LoginModel);
            if (response.Status)
            {
                return (200, response);
            }
            else
            {
                var Error = new ErrorResponseModel()
                {
                    Status = false,
                    Message = "Invalid Credential !"
                };
                return (400, Error);
            }

        }
    }
}
