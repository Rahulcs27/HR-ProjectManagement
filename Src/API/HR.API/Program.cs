
using HR.Identity;
using HR.Persistence;
using HR.Application;
using HR.Domain.Entities;

namespace HR.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddServiceRegistration(builder.Configuration);

            // builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

            // builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
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
            app.UseCors(x => x
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

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
