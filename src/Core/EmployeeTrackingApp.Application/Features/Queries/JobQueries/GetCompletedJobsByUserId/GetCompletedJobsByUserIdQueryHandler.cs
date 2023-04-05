using AutoMapper;
using EmployeeTrackingApp.Application.Interfaces.Repositories;
using EmployeeTrackingApp.Application.Responses.JobResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.JobQueries.GetCompletedJobsByUserId
{
    public class GetCompletedJobsByUserIdQueryHandler : IRequestHandler<GetCompletedJobsByUserIdQuery, List<GetAllJobsResponse>>
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public GetCompletedJobsByUserIdQueryHandler(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllJobsResponse>> Handle(GetCompletedJobsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _jobRepository.GetAllAsync(p => p.IsClosed && p.ClosedById == request.UserId);
            
            return _mapper.Map<List<GetAllJobsResponse>>(jobs);
        }
    }
}
