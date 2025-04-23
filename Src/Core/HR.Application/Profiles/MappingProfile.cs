using System;
using AutoMapper;
using HR.Application.Features.Countries.Commands.CreateCountry;
using HR.Application.Features.Countries.Commands.Dtos;
using HR.Application.Features.Countries.Commands.UpdateCountry;
using HR.Application.Features.States.Commands.CreateState;
using HR.Application.Features.States.Commands.Dtos;
using HR.Application.Features.States.Commands.UpdateState;
using HR.Domain.Entities;

namespace HR.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCountryDto, Country>();
        CreateMap<UpdateCountryDto, Country>();
        CreateMap<Country, CountryDto>();


        CreateMap<CreateStateDto, State>();
        CreateMap<UpdateStateDto, State>();
        CreateMap<State, StateDto>();
    }
}
