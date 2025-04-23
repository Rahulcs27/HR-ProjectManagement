 
using AutoMapper;
using HR.Application.Dtos;
using HR.Domain.Entity;

namespace HR.Application.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Tbl_LoginMaster, Tbl_LoginMasterDto>().ReverseMap();
        }
    }
}
