using EmployeeTrackingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Models
{
    public class JobModel
    {
        public Guid? Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public bool IsClosed { get; set; }

        public Guid? CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public Guid? AssignedToId { get; set; }
        public User AssignedTo { get; set; }

        public Guid? ApprovedById { get; set; }
        public User ApprovedBy { get; set; }

        public Guid? ClosedById { get; set; }
        public User ClosedBy { get; set; }

        public Guid DepartmentId { get; set; }
    }
}
