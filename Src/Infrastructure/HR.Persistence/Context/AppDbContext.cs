using HR.Application.Features.Cities.Commands.Dtos;
using HR.Application.Features.Countries.Commands.Dtos;
using HR.Application.Features.Designations.Commands.Dtos;
using HR.Application.Features.Employee.Queries.GetAllEmployees;
using HR.Application.Features.Employee.Queries.GetEmployeeProfile;
using HR.Application.Features.Holidays.Commands.Dtos;
using HR.Application.Features.Location.Query;
using HR.Application.Features.States.Commands.Dtos;
using HR.Application.Features.TimeSheet.Queries;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Context;
public class AppDbContext : DbContext

{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
     public DbSet<GetAllEmployeeVm> GetAllEmployeeVms { get; set; }
        public DbSet<FamilyMaster> FamilyMasters { get; set; }
        public DbSet<GetAllEmployeeVm> EmployeeProfiles { get; set; }
        public DbSet<Tbl_LoginMaster> Tbl_LoginMaster { get; set; }

    public DbSet<CountryDto> CountryDtos { get; set; }
    public DbSet<StateDto> StateDtos { get; set; }
    public DbSet<DesignationDto> DesignationDtos { get; set; }
    public DbSet<CityDto> CityDtos { get; set; }
    public DbSet<HolidayDto> HolidayDtos { get; set; }

    public DbSet<EmployeeDto> Employees { get; set; }
    public DbSet<GetAllLocationDto> dtos { get; set; }
    public DbSet<GetAllTimeSheetListDto> timeSheetListDtos { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    
    {
         modelBuilder.Entity<FamilyMaster>().HasKey(f => f.FamilyId);
         modelBuilder.Entity<GetEmployeeProfileQueryVm>().HasNoKey();
         modelBuilder.Entity<Tbl_LoginMaster>().HasNoKey();

        modelBuilder.Entity<CountryDto>().HasNoKey();
        modelBuilder.Entity<StateDto>().HasNoKey();
        modelBuilder.Entity<DesignationDto>().HasNoKey();
        modelBuilder.Entity<CityDto>().HasNoKey();
        modelBuilder.Entity<HolidayDto>().HasNoKey();
        modelBuilder.Entity<GetAllEmployeeVm>().HasNoKey();
           

        modelBuilder.Entity<EmployeeDto>().HasNoKey();
        modelBuilder.Entity<GetAllLocationDto>().HasNoKey();
        modelBuilder.Entity<GetAllTimeSheetListDto>().HasNoKey();






    }
}