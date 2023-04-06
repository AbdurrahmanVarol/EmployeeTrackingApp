using EmployeeTrackingApp.Application.Features.Commands.JobCommands.CreateJob;
using EmployeeTrackingApp.Application.Features.Queries.JobQueries.GetAssignedJobsByUserId;
using EmployeeTrackingApp.Application.Features.Queries.JobQueries.GetCompletedJobsByUserId;
using EmployeeTrackingApp.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeTrackingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private Guid UserId => Guid.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First().Value);

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("completed")]
        public async Task<IActionResult> GetCompletedJobs()
        {
            var jobs = await _mediator.Send(new GetCompletedJobsByUserIdQuery
            {
                UserId = UserId
            });
            return Ok(jobs);
        }
        [HttpGet("assigned")]
        public async Task<IActionResult> GetAssignedJobs()
        {
            var jobs = await _mediator.Send(new GetAssignedJobsByUserIdQuery
            {
                UserId = UserId
            });
            return Ok(jobs);
        }
        [HttpGet("unassigned")]
        public async Task<IActionResult> GetUnAssignedJobs()
        {
            var jobs = await _mediator.Send(new GetUnAssignedJobsByUserIdQuery());
            return Ok(jobs);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateJobCommand createJobCommand)
        {
            createJobCommand.CreatedAt = DateTime.Now;
            createJobCommand.CreatedById = UserId;
            var result = await _mediator.Send(createJobCommand);
            return Ok(new { IsSuccess = result != default(Guid)});
        }
        [HttpPut]
        public IActionResult Put([FromBody] JobModel jobModel)
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
