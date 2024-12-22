using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Areas.Admin.Models;
using TaskManagementApplication.DTOs.TaskCategory;
using TaskManagementApplication.Features.TaskCategories.Commands.Create;
using TaskManagementApplication.Features.TaskCategories.Commands.Delete;
using TaskManagementApplication.Features.TaskCategories.Commands.Edit;
using TaskManagementApplication.Features.TaskCategories.Queries;

namespace TaskManagementApi.Areas.Admin.Controllers
{
    [ApiController]
    [Route("api/v1/taskCategory/")]
    [Authorize]
    public class TaskCategoryController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public TaskCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetTaskCategoryList());
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _mediator.Send(new GetTaskCategoryById() { Id = id });
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskCategoryModel model)
        {

            var data = await _mediator.Send(new CreateTaskCategoryRequest() { CreateTaskCategoryDTO = new CreateTaskCategoryDTO() { Name = model.Name} });
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(EditTaskCategoryDTO editTaskCategoryDTO)
        {
            var response = await _mediator.Send(new EditTaskCategoryRequest() { EditTaskCategoryDTO = editTaskCategoryDTO });  
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int TaskCategoryId)
        {
            var response = await _mediator.Send(new DeleteTaskCategoryRequest() { TaskCategoryId = TaskCategoryId });  
            return Ok(response);
        }
    }
}
