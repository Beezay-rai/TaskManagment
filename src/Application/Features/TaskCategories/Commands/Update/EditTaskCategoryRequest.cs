using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs.TaskCategory;
using TaskManagementApplication.Exception;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskCategories.Commands.Edit
{
    public class EditTaskCategoryRequest : IRequest<ResponseModel>
    {
        public EditTaskCategoryDTO EditTaskCategoryDTO { get; set; }
    }

    public class EditTaskCategoryCommandHandler : IRequestHandler<EditTaskCategoryRequest, ResponseModel>
    {
        private readonly IGenericRepository<TaskCategory> _repo;
        private readonly IMapper _mapper;

        public EditTaskCategoryCommandHandler(IGenericRepository<TaskCategory> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(EditTaskCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel();


            try
            {
                var entity = _mapper.Map<TaskCategory>(request.EditTaskCategoryDTO);
                await _repo.UpdateAsync(entity);
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
