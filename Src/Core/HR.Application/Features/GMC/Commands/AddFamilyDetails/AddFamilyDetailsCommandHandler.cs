using AutoMapper;
using HR.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Domain.Entities;

namespace HR.Application.Features.GMC.Commands.AddFamilyDetails
{
    public class AddFamilyDetailsCommandHandler
    {
        private readonly IGmcRepository _repo;
        private readonly IMapper _mapper;

        public AddFamilyDetailsCommandHandler(IGmcRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AddFamilyDetailsCommandDto> Handle(AddFamilyDetailsCommand request, CancellationToken cancellationToken)
        {
            // Call the repository to create the family member
            var familyMember = await _repo.CreateFamilyMemberAsync(request.FamilyMaster);

            // Map the created family member to a family details command DTO and return
            return _mapper.Map<AddFamilyDetailsCommandDto>(familyMember);
        }
    }
}
