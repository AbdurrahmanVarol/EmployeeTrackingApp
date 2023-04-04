using AutoMapper;
using EmployeeTrackingApp.Application.Interfaces.Repositories;
using EmployeeTrackingApp.Application.Validations.FluentValidation;
using EmployeeTrackingApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Commands.JobCommands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobRepository;

        public CreateJobCommandHandler(IMapper mapper, IJobRepository jobRepository)
        {
            _mapper = mapper;
            _jobRepository = jobRepository;
        }

        public async Task<Guid> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = _mapper.Map<Job>(request);

            ValidatorTool.FluentValidate(new CreateJobValidator(), job);

            await _jobRepository.AddAsync(job);

            return job.Id;

        }
    }
}
