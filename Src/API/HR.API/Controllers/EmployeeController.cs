using HR.Application.Features.Employee.Commands.MakeEmployeeInactivate;
using HR.Application.Features.Employee.Queries.GetAllEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace HR.API.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

       

        [HttpGet("ALlEmployees")]
        public async Task<IActionResult> GetEmployees([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllEmployeeQuery { PageNumber = pageNumber, PageSize = pageSize };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("deactivate/{code}")]
        public async Task<IActionResult> DeactivateEmployee(string code)
        {
            var result = await _mediator.Send(new MakeEmployeeInactiveCommand(code));
            return Ok(new { message = result });
        }


    }
}
