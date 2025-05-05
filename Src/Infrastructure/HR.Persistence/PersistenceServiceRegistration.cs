using HR.Application.Contracts.Models.Persistence;
using HR.Application.Contracts.Persistence;
using HR.Identity.Services;
using HR.Persistence.Context;
using HR.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("hrWebApiConnString")));
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IGmcRepository, GmcRepository>();
            
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILoginService, LoginServices>();
            // Register IHttpContextAccessor
            //services.AddHttpContextAccessor();

            // Register IMemoryCache
            services.AddMemoryCache();


            services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILocationMasterRepository, LocationMasterRepository>();
            services.AddScoped<IBranchRepository,BranchRepository>();





            return services;
        }
    }
}
