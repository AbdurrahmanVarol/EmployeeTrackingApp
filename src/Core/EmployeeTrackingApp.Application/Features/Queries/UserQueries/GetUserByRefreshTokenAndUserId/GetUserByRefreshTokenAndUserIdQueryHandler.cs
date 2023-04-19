using AutoMapper;
using EmployeeTrackingApp.Application.Interfaces.Repositories;
using EmployeeTrackingApp.Application.Responses.UserResponses;
using EmployeeTrackingApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.UserQueries.GetUserByRefreshTokenAndUserId
{
    public class GetUserByRefreshTokenAndUserIdQueryHandler : IRequestHandler<GetUserByRefreshTokenAndUserIdQuery, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByRefreshTokenAndUserIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<User> Handle(GetUserByRefreshTokenAndUserIdQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetAsync(p=>p.Id == request.UserId && p.RefreshToken.Equals(request.RefreshToken));
            return user;
        }
    }
}
