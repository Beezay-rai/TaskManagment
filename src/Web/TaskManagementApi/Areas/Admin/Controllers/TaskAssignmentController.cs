using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApplication.DTOs.TaskAssignment;
using TaskManagementApplication.Features.TaskAssignments;

namespace TaskManagementApi.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskAssignmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskAssignmentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTaskAssignment()
        {
            var response = await _mediator.Send(new GetTaskAssignmentList());
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskAssignmentById(int id)
        {
            var data = await _mediator.Send(new GetTaskAssignmentById() { Id = id });
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAssignment(CreateTaskAssignmentDTO TaskAssignment)
        {
            var (code,response) = await _mediator.Send(new CreateTaskAssignment() { CreateTaskAssignmentDTO = TaskAssignment });
            return StatusCode(code,response);

        }

        [HttpPut]
        public async Task<IActionResult> EditTaskAssignment(EditTaskAssignmentDTO editTaskAssignmentDTO)
        {
            var response = await _mediator.Send(new EditTaskAssignment() { EditTaskAssignmentDTO = editTaskAssignmentDTO });
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int TaskAssignmentId)
        {
            var response = await _mediator.Send(new DeleteTaskAssignment() { TaskAssignmentId = TaskAssignmentId });
            return Ok(response);
        }
    }
}
