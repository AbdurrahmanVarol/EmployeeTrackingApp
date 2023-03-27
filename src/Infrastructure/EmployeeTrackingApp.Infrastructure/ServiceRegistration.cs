using EmployeeTrackingApp.Application.Interfaces.Services;
using EmployeeTrackingApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
           
            services.AddScoped<IAuthService,AuthService>();

        }
    }
}
