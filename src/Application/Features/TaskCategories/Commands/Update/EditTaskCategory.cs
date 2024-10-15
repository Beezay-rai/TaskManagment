using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs.TaskCategory;
using TaskManagementApplication.Exception;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskCategories.Commands.Edit
{
    public class EditTaskCategory : IRequest<ResponseModel>
    {
        public EditTaskCategoryDTO EditTaskCategoryDTO { get; set; }
    }

    public class EditTaskCategoryCommandHandler : IRequestHandler<EditTaskCategory, ResponseModel>
    {
        private readonly ITaskCategoryRepository _repo;
        private readonly IMapper _mapper;

        public EditTaskCategoryCommandHandler(ITaskCategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(EditTaskCategory request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel();


            try
            {
                var entity = _mapper.Map<TaskCategory>(request.EditTaskCategoryDTO);
                await _repo.Update(entity);
                response.Status = true;
                response.Message = "Updated Sucessfully !";

            }
            catch
            {
                response.Status = false;
                response.Message = "Failed to update Task Category with Id : "+request.EditTaskCategoryDTO.Id ;
            }
       


            return response;
        }
    }
}
