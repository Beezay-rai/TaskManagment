using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
