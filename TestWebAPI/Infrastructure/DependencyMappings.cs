using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Repository.Dapper;
using TestWebAPI.Repository.Interfaces;
using TestWebAPI.Repository.Repository;
using TestWebAPI.Service.Interfaces;
using TestWebAPI.Service.Service;
namespace TestWebAPI.Infrastructure
{
    public static class DependencyMappings
    {
        public static void DependencySetting(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<SqlHandler>();
            services.AddScoped<IDapper, Dapperr>();
        }
    }
}
