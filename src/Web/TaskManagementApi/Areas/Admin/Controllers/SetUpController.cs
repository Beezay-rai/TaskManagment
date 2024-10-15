using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApplication.DTOs;
using TaskManagementApplication.Features.TaskCategories.Commands.Create;
using TaskManagementApplication.Features.TaskCategories.Commands.Delete;
using TaskManagementApplication.Features.TaskCategories.Commands.Edit;
using TaskManagementApplication.Features.TaskCategories.Queries;

namespace TaskManagementApi.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetUpController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SetUpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //#region Department
        //[HttpGet]
        //public async Task<IActionResult> GetAllDepartment()
        //{
        //    var response = await _mediator.Send(new GetDepartmentList());
        //    return Ok(response);
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetDepartmentByid(int id)
        //{
        //    var data = await _mediator.Send(new GetDepartmentById() { Id = id });
        //    return Ok(data);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateDepartment(CreateDepartmentDTO Department)
        //{

        //    var data = await _mediator.Send(new CreateDepartment() { CreateDepartmentDTO = Department });
        //    return Ok(data);
        //}

        //[HttpPut]
        //public async Task<IActionResult> EditDepartment(EditDepartmentDTO editDepartmentDTO)
        //{
        //    var response = await _mediator.Send(new EditDepartment() { EditDepartmentDTO = editDepartmentDTO });
        //    return Ok(response);
        //}
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int DepartmentId)
        //{
        //    var response = await _mediator.Send(new DeleteDepartment() { DepartmentId = DepartmentId });
        //    return Ok(response);
        //}
        //#endregion

    }
}
