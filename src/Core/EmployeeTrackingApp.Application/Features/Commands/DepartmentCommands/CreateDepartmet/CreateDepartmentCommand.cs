using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Commands.CreateDepartmet
{
    public class CreateDepartmentCommand : IRequest<Guid>
    {
        public string DepartmentName { get; set; }
    }
}
