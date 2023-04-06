using AutoMapper;
using EmployeeTrackingApp.Application.Interfaces.Repositories;
using EmployeeTrackingApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.UserQueries.GetUserByUserName
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByUserNameQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(p => p.UserName.Equals(request.UserName));

            return user;
        }
    }
}
