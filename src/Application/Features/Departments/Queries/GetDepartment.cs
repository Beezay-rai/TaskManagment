using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
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
        private readonly IGenericRepository<Department> _repo;
        private readonly IMapper _mapper;
        public GetDepartmentByIdCommandHandler(IGenericRepository<Department> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<DepartmentDTO> Handle(GetDepartmentById request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repo.GetByIdAsync(request.Id);
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
        private readonly IGenericRepository<Department> _repo;

        public GetDepartmentListCommandHandler(IGenericRepository<Department> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<List<DepartmentDTO>> Handle(GetDepartmentList request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetAllAsync();
            var returndata = _mapper.Map<List<DepartmentDTO>>(data);

            return returndata;
        }
    }
}
