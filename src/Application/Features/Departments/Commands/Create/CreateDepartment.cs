using AutoMapper;using MediatR;using TaskManagement.Domain.Entities;using TaskManagementApplication.Common;using TaskManagementApplication.DTOs.Department;using TaskManagementApplication.Interfaces;namespace TaskManagementApplication.Features.Departments.Commands.Create{    public class CreateDepartment : IRequest<(int httpCode, object Data)>    {        public CreateDepartmentDTO CreateDepartmentDTO { get; set; }    }    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartment, (int httpCode, object Data)>    {        private readonly IGenericRepository<Department> _repo;        private readonly IMapper _mapper;        public CreateDepartmentCommandHandler(IGenericRepository<Department> repo, IMapper mapper)        {            _repo = repo;            _mapper = mapper;        }        public async Task<(int httpCode, object Data)> Handle(CreateDepartment request, CancellationToken cancellationToken)        {

            try            {
                var response = new ResponseModel();
                var validator = new DepartmentValidator<CreateDepartmentDTO>().Validate(request.CreateDepartmentDTO);
                if (!validator.IsValid)
                {
                    var ErrorModel = new ErrorResponseModel()
                    {
                        Status = false,
                        Message = "Validation Failed !",
                        ErrorDescription = validator.Errors.Select(x => x.ErrorMessage).ToList()

                    };
                    return (400, ErrorModel);
                }                var entity = _mapper.Map<Department>(request.CreateDepartmentDTO);                var createdEntity = await _repo.CreateAsync(entity);                response.Status = true;                response.Message = "Created Succfully with Id : " + createdEntity.Id;
                return (200, response);            }            catch (System.Exception e)            {                var error = new ErrorResponseModel()
                {
                    Status = false,
                    Message = e.InnerException.Message,

                };
                return (500, error);            }



        }    }}