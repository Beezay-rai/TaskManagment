using AutoMapper;
using MediatR;
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
        private readonly ITaskCategoryRepository _repo;
        private readonly IMapper _mapper;
        public GetTaskCategoryByIdCommandHandler(ITaskCategoryRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<TaskCategoryDTO> Handle(GetTaskCategoryById request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repo.GetById(request.Id);
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
        private readonly ITaskCategoryRepository _repo;

        public GetTaskCategoryListCommandHandler(ITaskCategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<List<TaskCategoryDTO>> Handle(GetTaskCategoryList request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetAll();
            var returndata = _mapper.Map<List<TaskCategoryDTO>>(data);

            return returndata;
        }
    }
}
