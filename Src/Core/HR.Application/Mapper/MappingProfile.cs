using AutoMapper;
using HR.Application.Features.Employee.Commands.CreateEmployeeMaster;
using HR.Application.Features.TimeSheet.Commands.CreateTimeSheet;
using HR.Domain.Entity;

namespace HR.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<TimeSheetDto, TimeSheet>();
            CreateMap<TimeSheet, TimeSheetDto>();
            CreateMap<CreateEmployeeMasterDto, EmployeeMaster>();
            CreateMap<EmployeeMaster, CreateEmployeeMasterDto>();

        }
    }
}
