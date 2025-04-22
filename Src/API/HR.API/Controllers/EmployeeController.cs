using HR.Application.Features.Employee.Commands.CreateEmployeeMaster;
using HR.Application.Features.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] CreateEmployeeCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var response = await _mediator.Send(new GetAllEmployeeQuery());
            return Ok(response);

        }
    }
}
