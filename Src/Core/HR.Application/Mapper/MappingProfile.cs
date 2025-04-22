using AutoMapper;
using HR.Application.Features.GMC.Commands.AddEmpDetails;
using HR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddEmpDetailsCommandDto, EmployeeMaster>();
        }
    }
}
