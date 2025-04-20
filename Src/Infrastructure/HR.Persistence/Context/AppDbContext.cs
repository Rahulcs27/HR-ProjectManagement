using System;
using HR.Application.Features.Countries.Commands.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<CountryDto> CountryDtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountryDto>().HasNoKey();
    }
}

