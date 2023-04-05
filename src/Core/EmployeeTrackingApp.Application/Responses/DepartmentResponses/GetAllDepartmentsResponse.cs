using EmployeeTrackingApp.Application.Responses.UserResponses;
using EmployeeTrackingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Responses.DepartmentResponses
{
    public class GetAllDepartmentsResponse
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<UserResponse> Users { get; set; }
    }
}
