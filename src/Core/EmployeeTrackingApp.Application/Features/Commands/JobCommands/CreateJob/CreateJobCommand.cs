using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Commands.JobCommands.CreateJob
{
    public class CreateJobCommand : IRequest<Guid>
    {
        public string Description { get; set; }
        public Guid CreatedById { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
