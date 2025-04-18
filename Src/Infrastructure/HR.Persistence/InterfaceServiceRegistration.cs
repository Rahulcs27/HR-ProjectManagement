using HR.Identity;
using HR.Identity.Contracts.Models.Persistence.Identity;
using HR.Identity.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Persistence
{
    public static  class InterfaceServiceRegistration
    {
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<hrIdentityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("hrWebApiConnString"))
            );
            services.AddScoped<ILoginService, LoginService>();
            return services;
        }
    }
}
