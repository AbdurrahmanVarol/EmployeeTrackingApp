using EmployeeTrackingApp.Application.Interfaces.Repositories;
using EmployeeTrackingApp.Domain.Entities;
using EmployeeTrackingApp.Persistence.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Persistence.EntityFramework.Repositories
{
    public class DepartmentRepository : EntityRepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeTrackingAppContext employeeTrackingAppContext) : base(employeeTrackingAppContext)
        {
        }
    }
}
