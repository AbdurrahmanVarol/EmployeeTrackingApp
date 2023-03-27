using AutoMapper;
using EmployeeTrackingApp.Application.Features.Commands.CreateDepartmet;
using EmployeeTrackingApp.Application.Features.Commands.CreateJob;
using EmployeeTrackingApp.Application.Features.Commands.CreateUser;
using EmployeeTrackingApp.Application.Responses;
using EmployeeTrackingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Mapping
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {
            CreateMap<Job, GetAllJobsResponse>().ReverseMap();
            CreateMap<CreateJobCommand, Job>().ReverseMap();

            CreateMap<CreateDepartmentCommand, Department>().ReverseMap();

            CreateMap<CreateUserCommand, User>().ReverseMap();
        }
    }
}
