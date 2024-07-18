using MediatR;
using TaskManagementApplication.Common;
using TaskManagementApplication.Exception;
using TaskManagementApplication.Interfaces;
using TaskManagementApplication.Models;

namespace TaskManagementApplication.Features.Authenticate.Commands
{
    public class SignUpCommand:IRequest<ResponseModel>
    {
        public SignUpModel SignUpModel { get; set; }    
    }

    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, ResponseModel>
    {
        private readonly IAuthenticateRepository _repo;

        public SignUpCommandHandler(IAuthenticateRepository repo)
        {
            _repo = repo;
        }

        public Task<ResponseModel> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var validator = new SignUpCommandValidator();
            var check = validator.Validate(request.SignUpModel);
            if (!check.IsValid)
                throw new ValidationException(check);
            return _repo.SignUp(request.SignUpModel);

        }
    }
}
