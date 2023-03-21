using EmployeeTrackingApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.GetAllJobs
{
    public class GetAllJobsQuery:IRequest<List<GetAllJobsResponse>>
    {
    }
}
