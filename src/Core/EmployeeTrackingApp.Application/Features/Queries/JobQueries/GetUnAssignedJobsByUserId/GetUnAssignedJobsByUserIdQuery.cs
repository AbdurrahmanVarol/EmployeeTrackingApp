using EmployeeTrackingApp.Application.Responses.JobResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.JobQueries.GetAssignedJobsByUserId
{
    public class GetUnAssignedJobsByUserIdQuery : IRequest<List<GetAllJobsResponse>>
    {        
    }
}
