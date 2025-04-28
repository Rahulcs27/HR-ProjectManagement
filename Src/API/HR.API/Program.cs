
using HR.Application.Contracts.Persistence;
using HR.Identity;
using HR.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using HR.Application;
using HR.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;



namespace HR.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            //builder.Services.AddIdentityServices(builder.Configuration);
            //builder.Services.AddInterfaceServices(builder.Configuration);
            // builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

            // builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());

            // Add DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("hrWebApiConnString")));

            // Register repository
            builder.Services.AddScoped<IEmployeeRepository, Employeerepository>();
            builder.Services.AddScoped<IGmcRepository, GmcRepository>();
            builder.Services.AddApplicationServices();
            


         
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            var app = builder.Build();

            //app.UseCors(x => x
            //                        .AllowAnyOrigin()
            //                        .AllowAnyMethod()
            //                        .AllowAnyHeader());
           
        

            app.UseCors("AllowAll");


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
