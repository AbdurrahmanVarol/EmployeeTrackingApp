using EmployeeTrackingApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Validations.FluentValidation
{
    public class CreateJobValidator : AbstractValidator<Job>
    {
        public CreateJobValidator()
        {
            RuleFor(p=>p.DepartmentId).NotEqual(default(Guid));
            RuleFor(p=>p.CreatedById).NotEqual(default(Guid));
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}
