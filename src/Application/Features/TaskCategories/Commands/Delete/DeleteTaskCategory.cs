using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs;
using TaskManagementApplication.Exception;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskCategories.Commands.Delete
{
    public class DeleteTaskCategory : IRequest<ResponseModel>
    {
        public int TaskCategoryId { get; set; }
    }

    public class DeleteTaskCategoryCommandHandler : IRequestHandler<DeleteTaskCategory, ResponseModel>
    {
        private readonly ITaskCategoryRepository _repo;
        private readonly IMapper _mapper;

        public DeleteTaskCategoryCommandHandler(ITaskCategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(DeleteTaskCategory request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel();
            //var validator = new DeleteTaskCategoryValidator().Validate(request.DeleteTaskCategoryDTO);
            //if (!validator.IsValid)
            //    throw new ValidationException(validator);

            try
            {
                var entity = _mapper.Map<TaskCategory>(request.TaskCategoryId);
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
