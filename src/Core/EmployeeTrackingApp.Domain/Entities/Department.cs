using EmployeeTrackingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Domain.Entities
{
    public class Department : BaseEntity
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
