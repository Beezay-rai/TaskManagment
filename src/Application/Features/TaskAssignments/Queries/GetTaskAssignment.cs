using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs.TaskAssignment;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskAssignments.Queries
{
    #region Query
    public class GetTaskAssignmentById : IRequest<(int HttpStatusCode, object data)>
    {
        public int Id { get; set; }
    }


    public class GetTaskAssignmentByIdCommandHandler : IRequestHandler<GetTaskAssignmentById, (int HttpStatusCode, object data)>
    {
        private readonly IGenericRepository<TaskAssignment> _repo;
        private readonly IMapper _mapper;
        public GetTaskAssignmentByIdCommandHandler(IGenericRepository<TaskAssignment> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<(int HttpStatusCode, object data)> Handle(GetTaskAssignmentById request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repo.GetByIdAsync(request.Id);
                if (data != null)
                {

                    var returnData = _mapper.Map<TaskAssignmentDTO>(data);
                    return (200, returnData);
                }
                else
                {
                    var errorModel = new ErrorResponseModel()
                    {
                        Message = "Not Found"
                    };
                    return (404, errorModel);
                }



            }
            catch (System.Exception e)
            {
                var errorModel = new ErrorResponseModel()
                {
                    Message = e.InnerException.Message,
                };
                return (500, errorModel);
            }
        }
    }


    public class GetTaskAssignmentList : IRequest<List<TaskAssignmentDTO>>
    {

    }
    public class GetTaskAssignmentListCommandHandler : IRequestHandler<GetTaskAssignmentList, List<TaskAssignmentDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TaskAssignment> _repo;

        public GetTaskAssignmentListCommandHandler(IGenericRepository<TaskAssignment> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<List<TaskAssignmentDTO>> Handle(GetTaskAssignmentList request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetAllAsync();
            var returndata = _mapper.Map<List<TaskAssignmentDTO>>(data);

            return returndata;
        }
    }
    #endregion
}
