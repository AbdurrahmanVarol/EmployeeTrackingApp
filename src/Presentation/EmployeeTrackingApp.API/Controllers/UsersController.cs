using EmployeeTrackingApp.Application.Features.Commands.CreateDepartmet;
using EmployeeTrackingApp.Application.Features.Commands.DepartmentCommands.DeleteDepartment;
using EmployeeTrackingApp.Application.Features.Commands.UpdateDepartment;
using EmployeeTrackingApp.Application.Features.Queries.GetAllDepartments;
using EmployeeTrackingApp.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
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
