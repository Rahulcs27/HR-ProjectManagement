using HR.Application.Contracts.Persistence;
using HR.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeMasterRepository
    {
        readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }


        public async Task<EmployeeMaster> AddEmployee(CreateEmployeeMasterDto employee)
        {
            string sql = @"EXEC SP_Employee_insert 
                    @Code = {0}, 
                    @Name = {1}, 
                    @Address = {2}, 
                    @MobileNo = {3}, 
                    @SkypeId = {4}, 
                    @JoinDate = {5}, 
                    @Email = {6}, 
                    @BccEmail = {7}, 
                    @PanNumber = {8}, 
                    @BirthDate = {9}, 
                    @Image = {10}, 
                    @Signature = {11}, 
                    @LoginStatus = {12}, 
                    @LeftCompany = {13}, 
                    @leftDate = {14}, 
                    @Fk_LocationId = {15}, 
                    @Fk_DesignationId = {16}, 
                    @Fk_ShiftId = {17}, 
                    @Fk_EmployeeTypeId = {18}, 
                    @Fk_UserGroupId = {19}";

            await _appDbContext.Database.ExecuteSqlRawAsync(
                sql,
                employee.Code,
                employee.Name,
                employee.Address,
                employee.MobileNo,
                employee.SkypeId,
                employee.JoinDate,
                employee.Email,
                employee.BccEmail,
                employee.PanNumber,
                employee.BirthDate,
                employee.Image,
                employee.Signature,
                employee.LoginStatus,
                employee.LeftCompany,
                employee.LeaveCompany,  // Fix: Property name corrected from `LeftCompany`
                employee.LocationId,
                employee.DesignationId,
                employee.ShiftId,
                employee.EmployeeTypeId,
                employee.UsergroupId
            );

            return new EmployeeMaster
            {
                Name = employee.Name,
                Code = employee.Code,
                Address = employee.Address,
                MobileNo = employee.MobileNo,
                SkypeId = employee.SkypeId,
                JoinDate = employee.JoinDate,
                Email = employee.Email,
                BccEmail = employee.BccEmail,
                PanNumber = employee.PanNumber,
                BirthtDate = employee.BirthDate,
                Image = employee.Image,
                Signature = employee.Signature,
                LoginStatus = employee.LoginStatus,
                LeftCompany = employee.LeftCompany,
                LeaveCompany = employee.LeaveCompany,  // Fix: Property name corrected
                CountryId = employee.LocationId,
                DesignationId = employee.DesignationId,
                ShiftId = employee.ShiftId,
                EmployeeTypeId = employee.EmployeeTypeId,
                UsergroupId = employee.UsergroupId,
            };
        }



    }
}









