
using HR.Application.Features.Employee.Queries.GetAllEmployees;
using HR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Persistence.Context
{
    public class AppDbContext : DbContext
    {
       

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<GetAllEmployeeVm> GetAllEmployeeVms { get; set; }
        public DbSet<FamilyMaster> FamilyMasters { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GetAllEmployeeVm>().HasNoKey();
            modelBuilder.Entity<FamilyMaster>()
     .HasKey(f => f.FamilyId);

        }
    }

}
