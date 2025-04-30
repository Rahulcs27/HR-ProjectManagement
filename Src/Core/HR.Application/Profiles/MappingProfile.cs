using System;
using AutoMapper;
using HR.Application.Features.Cities.Commands.CreateCity;
using HR.Application.Features.Cities.Commands.Dtos;
using HR.Application.Features.Cities.Commands.UpdateCity;
using HR.Application.Features.Countries.Commands.CreateCountry;
using HR.Application.Features.Countries.Commands.Dtos;
using HR.Application.Features.Countries.Commands.UpdateCountry;
using HR.Application.Features.Designations.Commands.CreateDesignation;
using HR.Application.Features.Designations.Commands.Dtos;
using HR.Application.Features.Designations.Commands.UpdateDesignation;
using HR.Application.Features.Divisions.Command.CreateLocationCommand;
using HR.Application.Features.Divisions.Command.Dto;
using HR.Application.Features.Divisions.Command.UpdateDivision;
using HR.Application.Features.Dtos;
using HR.Application.Features.Holidays.Commands.CreateHoliday;
using HR.Application.Features.Holidays.Commands.Dtos;
using HR.Application.Features.Holidays.Commands.UpdateHoliday;
using HR.Application.Features.Locations.Commands.CreateLocation;
using HR.Application.Features.Locations.Commands.UpdateLocation;
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

        CreateMap<CreateDesignationDto, Designation>();
        CreateMap<UpdateDesignationDto, Designation>();
        CreateMap<Designation, DesignationDto>();

        CreateMap<CreateCityDto, City>();
        CreateMap<UpdateCityDto, City>();
        CreateMap<City, CityDto>();

        CreateMap<CreateHolidayDto, Holiday>();
        CreateMap<UpdateHolidayDto, Holiday>();
        CreateMap<Holiday, HolidayDto>();



        CreateMap<Location, LocationDto>();
        CreateMap<CreateLocationDto, Location>();
        CreateMap<UpdateLocationDto, Location>();

        CreateMap<Division, DivisionDtos>();
        CreateMap<CreateDivisionDto, Division>();
        CreateMap<UpdateDivisionDto, Division>();
    }
}
