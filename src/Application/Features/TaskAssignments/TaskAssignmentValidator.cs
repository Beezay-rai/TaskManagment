using AutoMapper;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs.TaskAssignment;
using TaskManagementApplication.Interfaces;


namespace TaskManagementApplication.Features.TaskAssignments
{

    //#region Create

    //public class CreateTaskAssignmentCommand : IRequest<(int HttpStatusCode, object data)>
    //{
    //    public CreateTaskAssignmentDTO CreateTaskAssignmentDTO { get; set; }
    //}

    //public class CreateTaskAssignmentHandler : IRequestHandler<CreateTaskAssignmentCommand, (int HttpStatusCode, object data)>
    //{
    //    private readonly IMapper _mapper;
    //    private readonly IGenericRepository<TaskAssignment> _taskAssignment;
    //    public CreateTaskAssignmentHandler(IMapper mapper, IGenericRepository<TaskAssignment> taskAssignment)
    //    {
    //        _mapper = mapper;
    //        _taskAssignment = taskAssignment;
    //    }
    //    public async Task<(int HttpStatusCode, object data)> Handle(CreateTaskAssignmentCommand request, CancellationToken cancellationToken)
    //    {
    //        try
    //        {
    //            var response = new ResponseModel();
    //            var validate = new TaskAssignmentValidator<CreateTaskAssignmentDTO>(Operation.Add).Validate(request.CreateTaskAssignmentDTO);
    //            if (!validate.IsValid)
    //            {
    //                var errorModel = new ErrorResponseModel();
    //                errorModel.Message = " Validation Error !";
    //                errorModel.ErrorDescription = validate.Errors.Select(x => x.ErrorMessage).ToList();
    //                return (400, errorModel);
    //            }
    //            var model = _mapper.Map<TaskAssignment>(request.CreateTaskAssignmentDTO);
    //            var create = await _taskAssignment.CreateAsync(model);
    //            response.Data = new { CreatedId = create.Id };
    //            return (200, response);
    //        }
    //        catch (System.Exception e)
    //        {
    //            var errorModel = new ErrorResponseModel
    //            {
    //                Message = " Internal Server Error !",
    //                ErrorDescription = new List<string> { e.InnerException?.Message }
    //            };
    //            return (500, errorModel);
    //        }

    //    }
    //}
    //#endregion

    //#region Update

    //public class EditTaskAssignment : IRequest<(int HttpStatusCode, object data)>
    //{
    //    public EditTaskAssignmentDTO EditTaskAssignmentDTO { get; set; }
    //}

    //public class EditTaskAssignmentCommandHandler : IRequestHandler<EditTaskAssignment, (int HttpStatusCode, object data)>
    //{
    //    private readonly IGenericRepository<TaskAssignment> _repo;
    //    private readonly IMapper _mapper;

    //    public EditTaskAssignmentCommandHandler(IGenericRepository<TaskAssignment> repo, IMapper mapper)
    //    {
    //        _repo = repo;
    //        _mapper = mapper;
    //    }

    //    public async Task<(int HttpStatusCode, object data)> Handle(EditTaskAssignment request, CancellationToken cancellationToken)
    //    {
    //        var response = new ResponseModel();


    //        try
    //        {
    //            var entity = _mapper.Map<TaskAssignment>(request.EditTaskAssignmentDTO);
    //            await _repo.UpdateAsync(entity);
    //            response.Status = true;
    //            response.Message = "Updated Sucessfully !";
    //            return (200, response); 

    //        }
    //        catch(System.Exception e)
    //        {
    //            var errorModel = new ErrorResponseModel
    //            {
    //                Message = " Internal Server Error !",
    //                ErrorDescription = new List<string> { e.InnerException?.Message }
    //            };
    //            return (500, errorModel);
    //        }



    //    }
    //}
    //#endregion

    //#region Delete
    //public class DeleteTaskAssignment : IRequest<ResponseModel>
    //{
    //    public int TaskAssignmentId { get; set; }
    //}

    //public class DeleteTaskAssignmentCommandHandler : IRequestHandler<DeleteTaskAssignment, ResponseModel>
    //{
    //    private readonly IGenericRepository<TaskAssignment> _repo;
    //    private readonly IMapper _mapper;

    //    public DeleteTaskAssignmentCommandHandler(IGenericRepository<TaskAssignment> repo, IMapper mapper)
    //    {
    //        _repo = repo;
    //        _mapper = mapper;
    //    }

    //    public async Task<ResponseModel> Handle(DeleteTaskAssignment request, CancellationToken cancellationToken)
    //    {
    //        var response = new ResponseModel();
    //        //var validator = new DeleteTaskAssignmentValidator().Validate(request.DeleteTaskAssignmentDTO);
    //        //if (!validator.IsValid)
    //        //    throw new ValidationException(validator);

    //        try
    //        {
    //            var entity = _mapper.Map<TaskAssignment>(request.TaskAssignmentId);
    //            await _repo.DeleteAsync(entity.Id);
    //            response.Status = true;
    //            response.Message = "Deleted Succfully with Id : " + entity.Id;
    //        }
    //        catch
    //        {
    //            response.Status = false;
    //            response.Message = "Failed to Delete Task Category ! ";
    //        }



    //        return response;
    //    }
    //}

    //#endregion

    //#region Query
    //public class GetTaskAssignmentByIdRequest : IRequest<(int HttpStatusCode, object data)>
    //{
    //    public int Id { get; set; }
    //}


    //public class GetTaskAssignmentByIdCommandHandler : IRequestHandler<GetTaskAssignmentByIdRequest, (int HttpStatusCode, object data)>
    //{
    //    private readonly IGenericRepository<TaskAssignment> _repo;
    //    private readonly IMapper _mapper;
    //    public GetTaskAssignmentByIdCommandHandler(IGenericRepository<TaskAssignment> repo, IMapper mapper)
    //    {
    //        _mapper = mapper;
    //        _repo = repo;
    //    }

    //    public async Task<(int HttpStatusCode, object data)> Handle(GetTaskAssignmentByIdRequest request, CancellationToken cancellationToken)
    //    {
    //        try
    //        {
    //            var data = await _repo.GetByIdAsync(request.Id);
    //            if (data != null)
    //            {

    //            var returnData = _mapper.Map<TaskAssignmentDTO>(data);
    //            return (200,returnData);
    //            }
    //            else
    //            {
    //                var errorModel = new ErrorResponseModel()
    //                {
    //                    Message = "Not Found"
    //                };
    //                return (404, errorModel);
    //            }



    //        }
    //        catch(System.Exception e)
    //        {
    //            var errorModel = new ErrorResponseModel()
    //            {
    //                Message = e.InnerException.Message,
    //            };
    //            return (500, errorModel);
    //        }
    //    }
    //}


    //public class GetTaskAssignmentListRequest : IRequest<List<TaskAssignmentDTO>>
    //{

    //}
    //public class GetTaskAssignmentListCommandHandler : IRequestHandler<GetTaskAssignmentListRequest, List<TaskAssignmentDTO>>
    //{
    //    private readonly IMapper _mapper;
    //    private readonly IGenericRepository<TaskAssignment> _repo;

    //    public GetTaskAssignmentListCommandHandler(IGenericRepository<TaskAssignment> repo, IMapper mapper)
    //    {
    //        _repo = repo;
    //        _mapper = mapper;
    //    }


    //    public async Task<List<TaskAssignmentDTO>> Handle(GetTaskAssignmentListRequest request, CancellationToken cancellationToken)
    //    {
    //        var data = await _repo.GetAllAsync();
    //        var returndata = _mapper.Map<List<TaskAssignmentDTO>>(data);

    //        return returndata;
    //    }
    //}
    //#endregion

    #region Validator
    public class TaskAssignmentValidator<T> : AbstractValidator<T> where T : class
    {
        public TaskAssignmentValidator(Operation op)
        {

            switch (op)
            {
                case Operation.Add:
                    RuleFor(x => ((CreateTaskAssignmentDTO)(object)x).UserId).NotEmpty().WithMessage("{PropertyName} is required");
                    RuleFor(x => ((CreateTaskAssignmentDTO)(object)x).Remarks).NotEmpty().WithMessage("{PropertyName} is required");
                    break;


                default:
                    break;
            }
        }
    }
    #endregion


}
