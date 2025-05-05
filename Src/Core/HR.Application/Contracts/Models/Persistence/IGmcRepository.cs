using HR.Application.Features.GMC.Commands.AddFamilyDetails;
using HR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Contracts.Persistence
{
    public interface IGmcRepository
    {
        Task<int> AddEmpDetailsAsync(EmployeeMaster employee);
        Task<AddFamilyDetailsCommandDto> CreateFamilyMemberAsync(AddFamilyDetailsCommandDto dto);


    }
}
