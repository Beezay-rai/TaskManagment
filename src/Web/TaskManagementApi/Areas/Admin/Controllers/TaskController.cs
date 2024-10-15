using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApplication.DTOs.TaskEntity;
using TaskManagementApplication.Features.TaskCategories.Queries;
using TaskManagementApplication.Features.TaskEntities.Commands.Create;
using TaskManagementApplication.Features.TaskEntities.Queries;

namespace TaskManagementApi.Areas.Admin.Controllers
{
    [Route("api/[area]/Task/")]
    [Area("Admin")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllTask")]
        public async Task<IActionResult> GetAllTaskEntity()
        {
            Task.Delay(6000).Wait();
            var response = await _mediator.Send(new GetAllTaskEntity());
            return Ok(response);
        }
        [HttpGet("GetTaskById/{id}")]
        public async Task<IActionResult> GetTaskEntityByid(int id)
        {
            var data = await _mediator.Send(new GetTaskEntityById() { Id = id });
            return Ok(data);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult>CreateTaskEntity(CreateTaskEntityDTO model)
        {
            var response = await _mediator.Send(new CreateTaskEntity() { CreateTaskEntityDTO = model });
            return Ok(response);
        }
    }
}
