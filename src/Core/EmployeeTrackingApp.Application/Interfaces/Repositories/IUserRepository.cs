﻿using EmployeeTrackingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Interfaces.Repositories
{
    public interface IUserRepository : IEntityRepositoryAsync<User>
    {
    }
}
