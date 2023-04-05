using EmployeeTrackingApp.Application.Responses.DepartmentResponses;
using EmployeeTrackingApp.Application.Responses.UserResponses;
using EmployeeTrackingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Responses.JobResponses
{
    public class GetAllJobsResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public bool IsClosed { get; set; }

        public UserResponse CreatedBy { get; set; }
        public UserResponse AssignedTo { get; set; }
        public UserResponse ApprovedBy { get; set; }
        public UserResponse ClosedBy { get; set; }
        public DepartmentResponse Department { get; set; }
    }
}
