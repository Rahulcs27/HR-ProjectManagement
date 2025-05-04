using HR.Domain.Entities;

namespace HR.Application.Contracts.Persistence
{
    public interface IEmployeeMasterRepository
    {
        public Task<EmployeeMaster> AddEmployee(CreateEmployeeMasterDto employee);
        //public Task<List<Employee>> GetAllEmployee();
    }
}
