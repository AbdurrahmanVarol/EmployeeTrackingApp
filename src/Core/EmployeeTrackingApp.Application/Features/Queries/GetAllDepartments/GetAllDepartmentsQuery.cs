using EmployeeTrackingApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQuery : IRequest<List<GetAllDepartmentsResponse>>
    {
    }
}
