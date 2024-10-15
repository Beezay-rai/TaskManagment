using AutoMapper;
using MediatR;
using TaskManagementApplication.DTOs.Department;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.Departments.Queries
{
    public class GetDepartmentById : IRequest<DepartmentDTO>
    {
        public int Id { get; set; }
    }


    public class GetDepartmentByIdCommandHandler : IRequestHandler<GetDepartmentById, DepartmentDTO>
    {
        private readonly IDepartmentRepository _repo;
        private readonly IMapper _mapper;
        public GetDepartmentByIdCommandHandler(IDepartmentRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<DepartmentDTO> Handle(GetDepartmentById request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repo.GetById(request.Id);
                var returnData = _mapper.Map<DepartmentDTO>(data);
                return returnData;


            }
            catch
            {
                throw new System.Exception("Error :D");
            }
        }
    }


    public class GetDepartmentList : IRequest<List<DepartmentDTO>>
    {

    }
    public class GetDepartmentListCommandHandler : IRequestHandler<GetDepartmentList, List<DepartmentDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _repo;

        public GetDepartmentListCommandHandler(IDepartmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<List<DepartmentDTO>> Handle(GetDepartmentList request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetAll();
            var returndata = _mapper.Map<List<DepartmentDTO>>(data);

            return returndata;
        }
    }
}
