using System;
using AutoMapper;
using HR.Application.Features.Countries.Commands.Dtos;
using HR.Application.Interface;
using MediatR;

namespace HR.Application.Features.Countries.Commands.UpdateCountry;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, CountryDto>
{
    private readonly ICountryRepository _repo;
    private readonly IMapper _mapper;

    public UpdateCountryCommandHandler(ICountryRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<CountryDto> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var updated = await _repo.UpdateAsync(request.Country);
        return _mapper.Map<CountryDto>(updated);
    }
}

