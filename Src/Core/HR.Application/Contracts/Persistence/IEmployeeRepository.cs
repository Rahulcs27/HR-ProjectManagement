using HR.Application.Contracts.Models.Common;
using HR.Application.Features.Employee.Queries.GetAllEmployees;
using HR.Application.Features.Employee.Queries.GetEmployeeProfile;


namespace HR.Application.Contracts.Persistence
{
   public  interface IEmployeeRepository
    {
        
        Task<PaginatedResult<GetAllEmployeeVm>> GetAllEmployeeSummaryPagedAsync(int pageNumber, int pageSize);
        //Task<GetEmployeeProfileQueryVm> GetEmployeeProfileAsync(int id);
        Task<GetEmployeeProfileQueryVm> GetEmployeeProfileAsync(string Code);

        Task<string> MakeEmployeeInactiveAsync(string code);
        Task<string> MakeEmployeeActiveAsync(string code);
    }
}
