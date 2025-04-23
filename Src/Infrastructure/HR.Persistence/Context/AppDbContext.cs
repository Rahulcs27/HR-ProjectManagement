using System;
using HR.Application.Features.Countries.Commands.Dtos;
using HR.Application.Features.States.Commands.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<CountryDto> CountryDtos { get; set; }
    public DbSet<StateDto> StateDtos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountryDto>().HasNoKey();
        modelBuilder.Entity<StateDto>().HasNoKey();
    }
}

