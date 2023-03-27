﻿using EmployeeTrackingApp.Application.Features.Commands.CreateDepartmet;
using EmployeeTrackingApp.Application.Features.Commands.DepartmentCommands.DeleteDepartment;
using EmployeeTrackingApp.Application.Features.Commands.JobCommands.CreateJob;
using EmployeeTrackingApp.Application.Features.Commands.UpdateDepartment;
using EmployeeTrackingApp.Application.Features.Queries.GetAllDepartments;
using EmployeeTrackingApp.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeTrackingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobModel jobModel)
        {
            var command = new CreateJobCommand
            {
                Description = jobModel.Description,
                DepartmentId = jobModel.DepartmentId,
                CreatedById = UserId,
                
            };

            var result = await _mediator.Send(command);
            return Ok(new { IsSuccess = true });
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