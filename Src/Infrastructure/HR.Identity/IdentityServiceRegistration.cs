
using HR.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace HR.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<hrIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("hrWebApiConnString"));
            });
            services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<hrIdentityDbContext>().AddDefaultTokenProviders();
            return services;
        }
    }
}
