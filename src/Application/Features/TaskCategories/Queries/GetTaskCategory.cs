using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.DTOs.TaskCategory;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskCategories.Queries
{
    public class GetTaskCategoryById : IRequest<TaskCategoryDTO>
    {
        public int Id { get; set; }
    }


    public class GetTaskCategoryByIdCommandHandler : IRequestHandler<GetTaskCategoryById, TaskCategoryDTO>
    {
        private readonly IGenericRepository<TaskCategory> _repo;
        private readonly IMapper _mapper;
        public GetTaskCategoryByIdCommandHandler(IGenericRepository<TaskCategory> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<TaskCategoryDTO> Handle(GetTaskCategoryById request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repo.GetByIdAsync(request.Id);
                var returnData = _mapper.Map<TaskCategoryDTO>(data);
                return returnData;


            }
            catch
            {
                throw new System.Exception("Error :D");
            }
        }
    }


    public class GetTaskCategoryList : IRequest<List<TaskCategoryDTO>>
    {

    }
    public class GetTaskCategoryListCommandHandler : IRequestHandler<GetTaskCategoryList, List<TaskCategoryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TaskCategory> _repo;

        public GetTaskCategoryListCommandHandler(IGenericRepository<TaskCategory> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<List<TaskCategoryDTO>> Handle(GetTaskCategoryList request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetAllAsync();
            var returndata = _mapper.Map<List<TaskCategoryDTO>>(data);

            return returndata;
        }
    }
}
