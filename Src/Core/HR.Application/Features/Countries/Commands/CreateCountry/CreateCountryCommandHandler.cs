using System;
using AutoMapper;
using HR.Application.Features.Countries.Commands.Dtos;
using HR.Application.Interface;
using MediatR;

namespace HR.Application.Features.Countries.Commands.CreateCountry;
public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CountryDto>
{
    private readonly ICountryRepository _repo;
    private readonly IMapper _mapper;

    public CreateCountryCommandHandler(ICountryRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<CountryDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _repo.CreateAsync(request.Country);
        return _mapper.Map<CountryDto>(country);
    }
}

