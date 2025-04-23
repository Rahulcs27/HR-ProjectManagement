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

            string sql = @"EXEC SP_EmployeeModuleInsert 
            @UserName = {0}, 
            @Email = {1}, 
            @Password = {2}, 
            @Profile = {3}, 
            @Name = {4}, 
            @EmployeeCode = {5}, 
            @Fk_DesignationId = {6}, 
            @Fk_BranchId = {7}, 
            @Fk_DivisionId = {8}, 
            @Fk_EmployeeTypeId = {9}, 
            @LoginStatus = {10}, 
            @CreatedBy = {11}";

            Console.WriteLine("djfjdfnkjewf");
            await _appDbContext.Database.ExecuteSqlRawAsync(sql,
                 employee.UserName,
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
                Email = employee.Email,
                Password = employee.Password,
                //Profile = employee.Profile,
                EmployeeName = employee.Name,
                EmployeeCode = employee.Code,
                Fk_DesignationId = employee.DesignationId,
                Fk_BranchId = employee.BranchId,
                Fk_DivisionId = employee.DevisionId,
                Fk_EmployeeTypeId = employee.EmployeeTypeId,
                LoginStatus = employee.LoginStatus,
                CreatedBy = employee.CreatedBy
            };
        }






    }
}
