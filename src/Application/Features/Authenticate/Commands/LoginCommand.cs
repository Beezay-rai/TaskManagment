using MediatR;
using TaskManagementApplication.Common;
using TaskManagementApplication.Exception;
using TaskManagementApplication.Interfaces;
using TaskManagementApplication.Models;

namespace TaskManagementApplication.Features.Authenticate.Commands
{
    public class LoginCommand : IRequest<LoginResponseModel>
    {
        public LoginModel LoginModel { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseModel>
    {
        private readonly IAuthenticateRepository _repo;

        public LoginCommandHandler(IAuthenticateRepository repo)
        {
            _repo = repo;
        }

        public Task<LoginResponseModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginCommandValidator();
            var check =validator.Validate(request.LoginModel);
            if (!check.IsValid)
                throw new ValidationException(check);

            return _repo.Login(request.LoginModel);

        }
    }
}
