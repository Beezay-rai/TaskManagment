using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApplication.DTOs;
using TaskManagementApplication.Features.TaskCategories.Queries;
using TaskManagementApplication.Features.TaskEntities.Commands.Create;
using TaskManagementApplication.Features.TaskEntities.Queries;

namespace TaskManagementApi.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [Area("Admin")]
    [ApiController]
    public class TaskEntityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskEntityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTaskEntity()
        {

            var response = await _mediator.Send(new GetAllTaskEntity());
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskEntityByid(int id)
        {
            var data = await _mediator.Send(new GetTaskEntityById() { Id = id });
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult>CreateTaskEntity(CreateTaskEntityDTO model)
        {
            var response = await _mediator.Send(new CreateTaskEntity() { CreateTaskEntityDTO = model });
            return Ok(response);
        }
    }
}
