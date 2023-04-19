using EmployeeTrackingApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public UserRole UserRole { get; set; }
    }
}
