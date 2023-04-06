using EmployeeTrackingApp.Application.Features.Commands.CreateDepartmet;
using EmployeeTrackingApp.Application.Features.Commands.DepartmentCommands.DeleteDepartment;
using EmployeeTrackingApp.Application.Features.Commands.UpdateDepartment;
using EmployeeTrackingApp.Application.Features.Queries.UserQueries.GetAllUser;
using EmployeeTrackingApp.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }
        [HttpPost]
        public IActionResult Post([FromBody] DepartmentModel departmentModel)
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody] DepartmentModel departmentModel)
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}
