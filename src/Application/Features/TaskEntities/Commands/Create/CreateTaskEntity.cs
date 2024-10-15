using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs.TaskEntity;
using TaskManagementApplication.Exception;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskEntities.Commands.Create
{
    public class CreateTaskEntity : IRequest<ResponseModel>
    {
        public CreateTaskEntityDTO CreateTaskEntityDTO { get; set; }
    }

    public class CreateTaskEntityCommandHandler : IRequestHandler<CreateTaskEntity, ResponseModel>
    {
        private readonly ITaskEntityRepository _repo;
        private readonly IMapper _mapper;

        public CreateTaskEntityCommandHandler(ITaskEntityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(CreateTaskEntity request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel();
            var validator = new CreateTaskEntityValidator().Validate(request.CreateTaskEntityDTO);
            if (!validator.IsValid)
                throw new ValidationException(validator);


            var entity = _mapper.Map<TaskEntity>(request.CreateTaskEntityDTO);
            entity.CreatedBy = "Admin";
            var createdEntity = await _repo.Create(entity);
            response.Status = true;
            response.Message = "Created Succfully with Id : " + createdEntity.Id;


            return response;
        }
    }
}
