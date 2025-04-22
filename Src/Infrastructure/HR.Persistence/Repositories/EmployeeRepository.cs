using HR.Application.Contracts.Models.Common;
using HR.Application.Contracts.Persistence;
using HR.Application.Features.Employee.Queries.GetAllEmployees;
using HR.Domain.Entities;
using HR.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Persistence.Repositories
{
    public class Employeerepository : IEmployeeRepository

    {
        readonly AppDbContext _appDbContext;
        public Employeerepository(AppDbContext dbContext)
        {

            _appDbContext = dbContext;

        }

        public async Task<PaginatedResult<GetAllEmployeeVm>> GetAllEmployeeSummaryPagedAsync(int pageNumber, int pageSize)
        {
            var allData = await _appDbContext.GetAllEmployeeVms
                .FromSqlRaw("EXEC SP_GetAllEmployeeSummary")
                .ToListAsync();

            var totalCount = allData.Count;

            var pagedData = allData
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedResult<GetAllEmployeeVm>(pagedData, totalCount, pageNumber, pageSize);
        }

        //public async Task<string> MakeEmployeeInactiveAsync(int employeeId)
        //{
        //    var result = await _appDbContext
        //        .Database
        //        .ExecuteSqlRawAsync("EXEC SP_MakeEmployeeInactive @EmployeeId = {0}", employeeId);

        //    // Optional: return a custom success message
        //    return result > 0 ? "Employee is inactive successfully" : "Failed to inactivate employee";
        //}
        public async Task<string> MakeEmployeeInactiveAsync(string employeeCode)
        {
            var result = await _appDbContext
     .Database
     .ExecuteSqlRawAsync("EXEC dbo.SP_MakeEmployeeInactive @EmployeeCode = {0}", employeeCode);

            return result > 0 ? "Employee is inactive successfully" : "Failed to inactivate employee";
        }


    }
}
