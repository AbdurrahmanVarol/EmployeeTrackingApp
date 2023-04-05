using AutoMapper;
using EmployeeTrackingApp.Application.Features.Commands.CreateDepartmet;
using EmployeeTrackingApp.Application.Features.Commands.JobCommands.CreateJob;
using EmployeeTrackingApp.Application.Features.Commands.UserCommands.CreateUser;
using EmployeeTrackingApp.Application.Responses.DepartmentResponses;
using EmployeeTrackingApp.Application.Responses.JobResponses;
using EmployeeTrackingApp.Application.Responses.UserResponses;
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
            //Job Mapping
            CreateMap<Job, GetAllJobsResponse>()
                .ForMember(p => p.ApprovedBy, opt => opt.MapFrom(s => s.ApprovedBy))
                .ForMember(p => p.CreatedBy, opt => opt.MapFrom(s => s.CreatedBy))
                .ForMember(p => p.ClosedBy, opt => opt.MapFrom(s => s.ClosedBy))
                .ForMember(p => p.Department, opt => opt.MapFrom(s => s.Department))
                .ReverseMap();
            CreateMap<CreateJobCommand, Job>().ReverseMap();

            //Department Mapping
            CreateMap<CreateDepartmentCommand, Department>().ReverseMap();
            CreateMap<GetAllDepartmentsResponse, Department>().ReverseMap();
            CreateMap<DepartmentResponse, Department>().ReverseMap();


            //User Mapping
            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<UserResponse, User>()
                .ForMember(p=>p.Department,opt=>opt.MapFrom(s => s.Department))
                .ReverseMap();

        }
    }
}
