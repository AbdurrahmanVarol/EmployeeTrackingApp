using EmployeeTrackingApp.Application.Responses.DepartmentResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.DepartmentQueries.GetAllDepartments
{
    public class GetAllDepartmentsQuery : IRequest<List<GetAllDepartmentsResponse>>
    {
    }
}
