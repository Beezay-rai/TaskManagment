using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.DTOs.TaskEntity;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskEntities.Queries
{
    public class GetAllTaskEntity : IRequest<List<TaskEntityDTO>>
    {
    }
    public class GetAllTaskEntityCommandHandler : IRequestHandler<GetAllTaskEntity, List<TaskEntityDTO>>
    {
        private readonly IGenericRepository<TaskEntity> _repo;
        private readonly IMapper _mapper;

        public GetAllTaskEntityCommandHandler(IGenericRepository<TaskEntity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<TaskEntityDTO>> Handle(GetAllTaskEntity request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<TaskEntityDTO>>(data);
        }
    }
    public class GetTaskEntityById : IRequest<TaskEntityDTO>
    {
        public int Id { get; set; }
    }
    public class GetTaskEntityByIdCommandHandler : IRequestHandler<GetTaskEntityById, TaskEntityDTO>
    {
        private readonly IGenericRepository<TaskEntity> _repo;
        private readonly IMapper _mapper;

        public GetTaskEntityByIdCommandHandler(IGenericRepository<TaskEntity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TaskEntityDTO> Handle(GetTaskEntityById request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetByIdAsync(request.Id);
            return _mapper.Map<TaskEntityDTO>(data);
        }
    }
}
