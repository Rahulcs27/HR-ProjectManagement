using AutoMapper;

using HR.Domain.Entities;

namespace HR.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            
            CreateMap<CreateEmployeeMasterDto, EmployeeMaster>();
            CreateMap<EmployeeMaster, CreateEmployeeMasterDto>();

            //CreateMap<Employee, GetEmployeeVm>();

        }
    }
}
