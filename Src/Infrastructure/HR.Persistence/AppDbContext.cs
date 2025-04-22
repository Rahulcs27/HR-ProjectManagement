using HR.Application.Features.Employee.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<EmployeeDto> Employees { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDto>().HasNoKey();
        }
    }
}
