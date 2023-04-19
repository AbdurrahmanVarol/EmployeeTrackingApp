using EmployeeTrackingApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public UserRole UserRole { get; set; }
        public Guid? DeparmentId { get; set; }
        public string RefreshToken { get; set; }
    }
}
