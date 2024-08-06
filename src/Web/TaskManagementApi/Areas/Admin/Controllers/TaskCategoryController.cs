using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApplication.DTOs;
using TaskManagementApplication.Features.TaskCategories.Commands.Create;
using TaskManagementApplication.Features.TaskCategories.Commands.Delete;
using TaskManagementApplication.Features.TaskCategories.Commands.Edit;
using TaskManagementApplication.Features.TaskCategories.Queries;

namespace TaskManagementApi.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]/[action]")]
    [Authorize]
    public class TaskCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTaskCategory()
        {
            var response = await _mediator.Send(new GetTaskCategoryList());
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskCategoryByid(int id)
        {
            var data = await _mediator.Send(new GetTaskCategoryById() { Id = id });
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskCategory(CreateTaskCategoryDTO taskCategory)
        {

            var data = await _mediator.Send(new CreateTaskCategory() { CreateTaskCategoryDTO = taskCategory });
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> EditTaskCategory(EditTaskCategoryDTO editTaskCategoryDTO)
        {
            var response = await _mediator.Send(new EditTaskCategory() { EditTaskCategoryDTO = editTaskCategoryDTO });  
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int TaskCategoryId)
        {
            var response = await _mediator.Send(new DeleteTaskCategory() { TaskCategoryId = TaskCategoryId });  
            return Ok(response);
        }
    }
}
