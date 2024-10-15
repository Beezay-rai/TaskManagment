using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs;
using TaskManagementApplication.Exception;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.Departments.Commands.Delete
{
    public class DeleteDepartment : IRequest<ResponseModel>
    {
        public int DepartmentId { get; set; }
    }

    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartment, ResponseModel>
    {
        private readonly IDepartmentRepository _repo;
        private readonly IMapper _mapper;

        public DeleteDepartmentCommandHandler(IDepartmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(DeleteDepartment request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel();
            //var validator = new DeleteDepartmentValidator().Validate(request.DeleteDepartmentDTO);
            //if (!validator.IsValid)
            //    throw new ValidationException(validator);

            try
            {
                var entity = _mapper.Map<Department>(request.DepartmentId);
                await _repo.Delete(entity.Id);
                response.Status = true;
                response.Message = "Deleted Succfully with Id : " + entity.Id;
            }
            catch
            {
                response.Status = false;
                response.Message = "Failed to Delete Task Category ! ";
            }



            return response;
        }
    }
}
