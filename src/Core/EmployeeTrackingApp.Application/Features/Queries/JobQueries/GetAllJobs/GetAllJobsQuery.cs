using EmployeeTrackingApp.Application.Responses.JobResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.JobQueries.GetAllJobs
{
    public class GetAllJobsQuery : IRequest<List<GetAllJobsResponse>>
    {
    }
}
