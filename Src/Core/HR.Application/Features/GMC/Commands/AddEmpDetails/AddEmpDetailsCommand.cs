using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Features.GMC.Commands.AddEmpDetails
{
    public class AddEmpDetailsCommand:IRequest<int>
    {
        public AddEmpDetailsCommandDto EmpDetails { get; set; }
        public AddEmpDetailsCommand(AddEmpDetailsCommandDto empDetails)
        {
            EmpDetails = empDetails;
        }
    }
}
