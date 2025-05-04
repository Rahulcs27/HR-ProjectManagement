using HR.Application.Features.Employee.Dtos;
using HR.Application.Features.Location.Query;
using HR.Application.Features.TimeSheet.Queries;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<EmployeeDto> Employees { get; set; }
        public DbSet<GetAllLocationDto> dtos { get; set; }
        public DbSet<GetAllTimeSheetListDto> timeSheetListDtos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDto>().HasNoKey();
            modelBuilder.Entity<GetAllLocationDto>().HasNoKey();
            modelBuilder.Entity<GetAllTimeSheetListDto>().HasNoKey();
        }
    }
}
