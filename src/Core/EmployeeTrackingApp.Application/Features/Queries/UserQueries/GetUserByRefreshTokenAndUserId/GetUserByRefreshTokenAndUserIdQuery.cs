using EmployeeTrackingApp.Application.Responses.UserResponses;
using EmployeeTrackingApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.UserQueries.GetUserByRefreshTokenAndUserId
{
    public class GetUserByRefreshTokenAndUserIdQuery : IRequest<User>
    {
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }
    }
}
