using AutoMapper;
using EmployeeTrackingApp.Application.Interfaces.Repositories;
using EmployeeTrackingApp.Application.Responses.JobResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.JobQueries.GetAllJobs
{
    public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, List<GetAllJobsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobRepository;


        public GetAllJobsQueryHandler(IMapper mapper, IJobRepository jobRepository)
        {
            _mapper = mapper;
            _jobRepository = jobRepository;
        }

        public async Task<List<GetAllJobsResponse>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _jobRepository.GetAllAsync();
            var response = _mapper.Map<List<GetAllJobsResponse>>(jobs);

            return response;
        }
    }
}
