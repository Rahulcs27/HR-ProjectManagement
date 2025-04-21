using HR.Application.Features.Employee.Commands.CreateEmployeeMaster;
using HR.Domain.Entity;

namespace HR.Application.Contracts.Persistence
{
    public interface IEmployeeMasterRepository
    {
        public Task<EmployeeMaster> AddEmployee(CreateEmployeeMasterDto employee);
    }
}
