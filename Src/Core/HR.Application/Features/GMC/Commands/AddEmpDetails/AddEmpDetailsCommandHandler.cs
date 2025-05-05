//using AutoMapper;
//using HR.Application.Contracts.Persistence;
//using HR.Domain.Entities;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HR.Application.Features.GMC.Commands.AddEmpDetails
//{
//    public class AddEmpDetailsCommandHandler : IRequestHandler<AddEmpDetailsCommand, int>

//    {
//        private readonly IGmcRepository _repo;
//        private readonly IMapper _mapper;

//        public AddEmpDetailsCommandHandler(IGmcRepository repo, IMapper mapper)
//        {
//            _repo = repo;
//            _mapper = mapper;
//        }

//        public async Task<int> Handle(AddEmpDetailsCommand request, CancellationToken cancellationToken)
//        {
//            var employeeEntity = _mapper.Map<Employee>(request.EmpDetails);
//            var id = await _repo.AddEmpDetailsAsync(employeeEntity);
//            return id;
//        }
        
//    }
//}
