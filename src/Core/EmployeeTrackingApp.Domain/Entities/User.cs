using EmployeeTrackingApp.Domain.Common;
using EmployeeTrackingApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public UserRole UserRole { get; set; }
        public string RefreshToken { get; set; }

        public Guid? DeparmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
