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
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
