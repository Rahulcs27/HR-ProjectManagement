using HR.Domain.Entities;

namespace HR.Application.Contracts.Models.Persistence
{
    public interface IEmployeeRepository
    {
        public Task<EmployeeMaster> AddEmployee(CreateEmployeeMasterDto employee);
        //public Task<List<Employee>> GetAllEmployee();
    }
}
