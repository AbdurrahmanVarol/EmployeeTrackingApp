using EmployeeTrackingApp.Application.Responses.UserResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.UserQueries.GetAllUser
{
    public class GetAllUsersQuery : IRequest<List<UserResponse>>
    {
    }
}
