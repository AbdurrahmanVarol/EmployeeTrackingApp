using EmployeeTrackingApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Features.Queries.UserQueries.GetUserByUserName
{
    public class GetUserByUserNameQuery : IRequest<User>
    {
        //TODO: User yerine dto dönüledek 
        public string UserName { get; set; }
    }
}
