using EmployeeTrackingApp.Application.Features.Commands.CreateDepartmet;
using EmployeeTrackingApp.Application.Features.Commands.DepartmentCommands.DeleteDepartment;
using EmployeeTrackingApp.Application.Features.Commands.UpdateDepartment;
using EmployeeTrackingApp.Application.Features.Queries.GetAllDepartments;
using EmployeeTrackingApp.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var departments = await _mediator.Send(new GetAllDepartmentsQuery());
            return Ok(departments);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartmentModel departmentModel)
        {
            await _mediator.Send(new CreateDepartmentCommand { DepartmentName = departmentModel.DepartmentName });

            var departments = await _mediator.Send(new GetAllDepartmentsQuery());
            return Ok(new { Departments = departments });
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DepartmentModel departmentModel)
        {
            var result = await _mediator.Send(new UpdateDepartmentCommand { Id = (Guid)departmentModel.Id, DepartmentName = departmentModel.DepartmentName });
            return Ok(new { result });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteDepartmentCommand { Id = id });
            return Ok();
        }
    }
}
