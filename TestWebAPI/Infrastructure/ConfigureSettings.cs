using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Repository.Common;
using TestWebAPI.Utility;

namespace TestWebAPI.Infrastructure
{
    public static class ConfigurationSettings
    {
        public static void Configure(IServiceCollection services, IConfiguration _config)
        {
            services.Configure<AppSettings>(_config.GetSection("AppSettings"));
            services.AddTransient(sp => sp.GetService<IOptionsSnapshot<AppSettings>>().Value);
            ContextSettings.ConnectionStrings = Convert.ToString(_config["AppSettings:ConnectionStrings:DefaultConnection"]);
            JwtConfig.JwtKey = Convert.ToString(_config["Jwt:Key"]);
            JwtConfig.JwtIssuer = Convert.ToString(_config["Jwt:Issuer"]);
        }
    }
}
