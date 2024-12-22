using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApplication.DTOs.TaskAssignment;
using TaskManagementApplication.Features.TaskAssignments;
using TaskManagementApplication.Features.TaskAssignments.Commands.Create;
using TaskManagementApplication.Features.TaskAssignments.Commands.Delete;
using TaskManagementApplication.Features.TaskAssignments.Commands.Update;
using TaskManagementApplication.Features.TaskAssignments.Queries;

namespace TaskManagementApi.Areas.Admin.Controllers
{
    [Route("api/v1/assign")]
    [ApiController]
    public class TaskAssignmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskAssignmentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetTaskAssignmentList());
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _mediator.Send(new GetTaskAssignmentById() { Id = id });
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateTaskAssignmentDTO TaskAssignment)
        {
            var  response= await _mediator.Send(new CreateTaskAssignmentCommand() { CreateTaskAssignmentDTO = TaskAssignment });
            return StatusCode(200, response);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id,EditTaskAssignmentDTO editTaskAssignmentDTO)
        {
            var response = await _mediator.Send(new EditTaskAssignment() { EditTaskAssignmentDTO = editTaskAssignmentDTO });
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int TaskAssignmentId)
        {
            var response = await _mediator.Send(new DeleteTaskAssignment() { TaskAssignmentId = TaskAssignmentId });
            return Ok(response);
        }
    }
}
