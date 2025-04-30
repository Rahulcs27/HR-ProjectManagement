using AutoMapper;
using HR.Application.Features.TimeSheet.Commands.CreateTimeSheet;
using HR.Domain.Entities;

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

            //CreateMap<Employee, GetEmployeeVm>();

        }
    }
}
