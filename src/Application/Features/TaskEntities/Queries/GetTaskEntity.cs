using AutoMapper;
using MediatR;
using TaskManagementApplication.DTOs.TaskEntity;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskEntities.Queries
{
    public class GetAllTaskEntity : IRequest<List<TaskEntityDTO>>
    {
    }
    public class GetAllTaskEntityCommandHandler : IRequestHandler<GetAllTaskEntity, List<TaskEntityDTO>>
    {
        private readonly ITaskEntityRepository _repo;
        private readonly IMapper _mapper;

        public GetAllTaskEntityCommandHandler(ITaskEntityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<TaskEntityDTO>> Handle(GetAllTaskEntity request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetAll();
            return _mapper.Map<List<TaskEntityDTO>>(data);
        }
    }
    public class GetTaskEntityById : IRequest<TaskEntityDTO>
    {
        public int Id { get; set; }
    }
    public class GetTaskEntityByIdCommandHandler : IRequestHandler<GetTaskEntityById, TaskEntityDTO>
    {
        private readonly ITaskEntityRepository _repo;
        private readonly IMapper _mapper;

        public GetTaskEntityByIdCommandHandler(ITaskEntityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TaskEntityDTO> Handle(GetTaskEntityById request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetById(request.Id);
            return _mapper.Map<TaskEntityDTO>(data);
        }
    }
}
