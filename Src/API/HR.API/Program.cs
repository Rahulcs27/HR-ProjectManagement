using HR.Application;
using HR.Application.Contracts.Models.Persistence;
using HR.Application.Mapper;
using HR.Domain.Entities;
using HR.Persistence;
using HR.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

using HR.Application.Profiles;
using HR.Persistence.Context;


namespace HR.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("HrConnString");

            // Register DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connString),
                ServiceLifetime.Scoped
            );

            // Register Application Services
            builder.Services.AddApplicationServices();
            builder.Services.AddServiceRegistration(builder.Configuration);

            //------------------------------------------------------------------------------------------
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddMemoryCache();
            //------------------------------------------------------------------------------------------

            // Register Repositories
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));  // Ensure MappingProfile is the correct profile class

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddServiceRegistration(builder.Configuration);


            // builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddControllers();
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


            // CORS policy
            builder.Services.AddCors(o => o.AddPolicy("MyPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    }));

            //app.UseCors(x => x
            //                        .AllowAnyOrigin()
            //                        .AllowAnyMethod()
            //                        .AllowAnyHeader());
           
        

            app.UseCors("AllowAll");


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
