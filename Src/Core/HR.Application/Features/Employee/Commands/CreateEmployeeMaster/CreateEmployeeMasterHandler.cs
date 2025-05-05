using AutoMapper;
using HR.Application.Contracts.Models.Persistence;
using MediatR;

namespace HR.Application.Features.Employee.Commands.CreateEmployeeMaster
{
    public class CreateEmployeeMasterHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeMasterDto>
    {
        readonly IMapper _mapper;
        readonly IEmployeeRepository _employeeMasterRepository;
        public CreateEmployeeMasterHandler(IMapper mapper, IEmployeeRepository iEmployeeMasterRepository)
        {

            _employeeMasterRepository = iEmployeeMasterRepository;
            _mapper = mapper;
        }


        public async Task<CreateEmployeeMasterDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeMasterRepository.AddEmployee(request.newEmployee);

            return _mapper.Map<CreateEmployeeMasterDto>(employee);
        }
    }
}
