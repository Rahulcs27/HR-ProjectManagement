using AutoMapper;
using HR.Application.Features.Location.Query;
using HR.Application.Features.TimeSheet.Commands.CreateTimeSheet;
using HR.Domain.Entities;
using HR.Domain.Entity;

namespace HR.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<CreateTimeSheetDto, TimeSheet>();
            CreateMap<TimeSheet, CreateTimeSheetDto>();
            CreateMap<CreateEmployeeMasterDto, EmployeeMaster>()
    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image != null ? Convert.FromBase64String(src.Image) : null)) // Decode Base64 string to byte[] 
    .ForMember(dest => dest.Signature, opt => opt.MapFrom(src => src.Signature != null ? Convert.FromBase64String(src.Signature) : null)) // Decode Base64 string to byte[]
    .ForMember(dest => dest.JoinDate, opt => opt.MapFrom(src => src.JoinDate));

            CreateMap<EmployeeMaster, CreateEmployeeMasterDto>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image != null ? Convert.ToBase64String(src.Image) : null)) // Encode byte[] to Base64 string
                .ForMember(dest => dest.Signature, opt => opt.MapFrom(src => src.Signature != null ? Convert.ToBase64String(src.Signature) : null)); // Encode byte[] to Base64 string



            CreateMap<Location, GetAllLocationDto>();

            //CreateMap<Employee, GetEmployeeVm>();

        }
    }
}
