using EmployeeTrackingApp.Application.Interfaces.Repositories;
using EmployeeTrackingApp.Persistence.EntityFramework.Context;
using EmployeeTrackingApp.Persistence.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<EmployeeTrackingAppContext>(options =>
            {
                options.UseSqlServer("");
            });

            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IJobRepository,JobRepository>();
            services.AddScoped<IDepartmentRepository,DepartmentRepository>();
        }
    }
}
