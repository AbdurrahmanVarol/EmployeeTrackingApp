using EmployeeTrackingApp.Application.Responses.DepartmentResponses;
using EmployeeTrackingApp.Domain.Entities;
using EmployeeTrackingApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Responses.UserResponses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; }
        public string UserName { get; set; }
        public UserRole UserRole { get; set; }

        public DepartmentResponse Department { get; set; }
    }
}
