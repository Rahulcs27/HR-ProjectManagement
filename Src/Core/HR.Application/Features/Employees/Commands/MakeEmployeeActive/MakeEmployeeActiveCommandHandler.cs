using AutoMapper;
using HR.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Features.Employee.Commands.MakeEmployeeActive
{
    public class MakeEmployeeActiveCommandHandler : IRequestHandler<MakeEmployeeActiveCommand, string>
    {

        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public MakeEmployeeActiveCommandHandler(IEmployeeRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<string> Handle(MakeEmployeeActiveCommand request,CancellationToken cancellationToken)
        {
            return await _repo.MakeEmployeeActiveAsync(request.Code);
        }
    }
}