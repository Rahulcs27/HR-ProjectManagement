using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Features.Employee.Commands.MakeEmployeeInactivate
{
    public class MakeEmployeeInactiveCommand:IRequest<string>
    {
        public string  EmployeeCode { get; set; }
        public MakeEmployeeInactiveCommand(string employeeCode)
        {
            EmployeeCode = employeeCode;
        }
    }
}
