using HR.Application.Contracts.Models.Persistence;
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
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IDivisionRepositry, DivisionRepository>();





            return services;
        }
    }
}
