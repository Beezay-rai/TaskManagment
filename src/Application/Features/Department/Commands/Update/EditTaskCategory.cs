using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs.Department;
using TaskManagementApplication.Exception;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.Departments.Commands.Edit
{
    public class EditDepartment : IRequest<ResponseModel>
    {
        public EditDepartmentDTO EditDepartmentDTO { get; set; }
    }

    public class EditDepartmentCommandHandler : IRequestHandler<EditDepartment, ResponseModel>
    {
        private readonly IDepartmentRepository _repo;
        private readonly IMapper _mapper;

        public EditDepartmentCommandHandler(IDepartmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(EditDepartment request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel();


            try
            {
                var entity = _mapper.Map<Department>(request.EditDepartmentDTO);
                await _repo.Update(entity);
                response.Status = true;
                response.Message = "Updated Sucessfully !";

            }
            catch
            {
                response.Status = false;
                response.Message = "Failed to update Task Category with Id : "+request.EditDepartmentDTO.Id ;
            }
       


            return response;
        }
    }
}
