using HR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.SharePoint.Client;

namespace HR.Persistence
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<EmployeeMaster> Tbl_EmployeeMaster { get; set; }
        public DbSet<Tbl_LoginMaster> Tbl_LoginMaster {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tbl_LoginMaster>();
            modelBuilder.Entity<EmployeeMaster>()
                .ToTable("Tbl_EmployeeMaster"); // Maps to dbo.Tbl_EmployeeMaster
        }
    }
}
