using HR.Application.Contracts.Persistence;
using HR.Application.Features.Employee.Commands.CreateEmployeeMaster;
using HR.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Repositories
{
    public class EmployeeRepo : IEmployeeMasterRepository
    {
        readonly AppDbContext _appDbContext;
        public EmployeeRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }


        public async Task<EmployeeMaster> AddEmployee(CreateEmployeeMasterDto employee)
        {

            string sql = @"EXEC sp_EmployeeInsert 
            @UserName = {0}, 
            @Employeename = {1},
            @Email = {2}, 
            @Password = {3}, 
            @Profile = {4}, 
            @Name = {5}, 
            @EmployeeCode = {6}, 
            @Fk_DesignationId = {7}, 
            @Fk_BranchId = {8}, 
            @Fk_DivisionId = {9}, 
            @Fk_EmployeeTypeId = {10}, 
            @LoginStatus = {11}, 
            @CreatedBy = {12}";

            await _appDbContext.Database.ExecuteSqlRawAsync(sql,
                 employee.UserName,
                 employee.EmployeeName,
                 employee.Email,
                 employee.Password,
                 employee.Profile,
                 employee.Name,
                 employee.Code ?? (object)DBNull.Value,
                 employee.DesignationId,
                 employee.BranchId,
                 employee.DevisionId,
                 employee.EmployeeTypeId,
                 employee.LoginStatus,
                 employee.CreatedBy
            );


            return new EmployeeMaster
            {
                UserName = employee.UserName,
                EmployeeName = employee.EmployeeName,
                Email = employee.Email,
                Password = employee.Password,
                Profile = employee.Profile,
                Name = employee.Name,
                Code = employee.Code,
                DesignationId = employee.DesignationId,
                BranchId = employee.BranchId,
                DevisionId = employee.DevisionId,
                EmployeeTypeId = employee.EmployeeTypeId,
                LoginStatus = employee.LoginStatus,
                CreatedBy = employee.CreatedBy
            };
        }



        public async Task<List<Employee>> GetAllEmployee()
        {
            return await _appDbContext.Employees
                .FromSqlRaw("EXEC sp_Employee")
                .ToListAsync();
        }

    }

}