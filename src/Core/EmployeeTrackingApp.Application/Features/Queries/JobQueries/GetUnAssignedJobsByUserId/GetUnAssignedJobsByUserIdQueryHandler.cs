using AutoMapper;
using EmployeeTrackingApp.Application.Interfaces.Repositories;
using EmployeeTrackingApp.Application.Responses.JobResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.JobQueries.GetAssignedJobsByUserId
{
    public class GetUnAssignedJobsByUserIdQueryHandler : IRequestHandler<GetUnAssignedJobsByUserIdQuery, List<GetAllJobsResponse>>
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public GetUnAssignedJobsByUserIdQueryHandler(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllJobsResponse>> Handle(GetUnAssignedJobsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _jobRepository.GetAllAsync(p => !p.IsClosed && p.ApprovedById == null);

            return _mapper.Map<List<GetAllJobsResponse>>(jobs);
        }
    }
}
