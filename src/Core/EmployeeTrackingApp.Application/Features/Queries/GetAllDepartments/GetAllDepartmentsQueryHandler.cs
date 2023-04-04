using AutoMapper;
using EmployeeTrackingApp.Application.Interfaces.Repositories;
using EmployeeTrackingApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<GetAllDepartmentsResponse>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllDepartmentsResponse>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = (await _departmentRepository.GetAllAsync()).OrderBy(p=>p.DepartmentName).ToList();
            

            return _mapper.Map<List<GetAllDepartmentsResponse>>(departments);;

        }
    }
}
