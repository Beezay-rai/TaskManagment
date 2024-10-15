using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs.TaskAssignment;
using TaskManagementApplication.Exception;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskAssignments.Commands.Create
{
    public class CreateTaskAssignment : IRequest<ResponseModel>
    {
        public CreateTaskAssignmentDTO CreateTaskAssignmentDTO { get; set; }
    }

    public class CreateTaskAssignmentCommandHandler : IRequestHandler<CreateTaskAssignment, ResponseModel>
    {
        private readonly ITaskAssignmentRepository _repo;
        private readonly IMapper _mapper;

        public CreateTaskAssignmentCommandHandler(ITaskAssignmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(CreateTaskAssignment request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel();
            var validator = new CreateTaskAssignmentValidator().Validate(request.CreateTaskAssignmentDTO);
            if (!validator.IsValid)
                throw new ValidationException(validator);

            try
            {
                var entity = _mapper.Map<TaskAssignment>(request.CreateTaskAssignmentDTO);
                var createdEntity = await _repo.Create(entity);
                response.Status = true;
                response.Message = "Created Succfully with Id : " + createdEntity.Id;
            }
            catch
            {
                response.Status = false;
                response.Message = "Failed to create Task Category ! ";
            }



            return response;
        }
    }
}
