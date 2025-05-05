using AutoMapper;
using HR.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Features.Employee.Commands.MakeEmployeeInactivate
{
    public class MakeEmployeeInactiveCommandHandler : IRequestHandler<MakeEmployeeInactiveCommand, string>
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        public MakeEmployeeInactiveCommandHandler(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<string> Handle(MakeEmployeeInactiveCommand request,CancellationToken cancellationToken)
        {
            return await _repo.MakeEmployeeInactiveAsync(request.Code);
        }
    }
}
