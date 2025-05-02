
using MediatR;
using Microsoft.AspNetCore.Mvc;


using HR.Application.Features.Employee.Queries;


using HR.Application.Features.Employee.Commands.MakeEmployeeInactivate;
using HR.Application.Features.Employee.Queries.GetAllEmployees;
using HR.Application.Features.Employee.Commands.MakeEmployeeActive;
using HR.Application.Features.Employee.Queries.GetEmployeeProfile;

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
        [HttpGet("ProfileDetalis/{code}")]
        public async Task<IActionResult> GetEmployeeProfile(string code)
        {
            var query = new GetEmployeeProfileQuery(code);
            var employeeProfile = await _mediator.Send(query);

            if (employeeProfile == null)
            {
                return NotFound();
            }

            return Ok(employeeProfile);
        }

        //        [HttpGet("ProfileDetalis")]
        //public async Task<IActionResult> GetEmployeeProfile()
        //{
        //    var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    if (string.IsNullOrEmpty(userIdClaim))
        //        return Unauthorized();

        //    int userId = int.Parse(userIdClaim);

        //    var query = new GetEmployeeProfileQuery(userId);
        //    var employeeProfile = await _mediator.Send(query);

        //    if (employeeProfile == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(employeeProfile);
        //}

        [HttpPost("Inactivate/{code}")]
        public async Task<IActionResult> InactivateEmployee(string code)
        {
            code = code?.Trim();// to trim the extra space or tabs
            var result = await _mediator.Send(new MakeEmployeeInactiveCommand(code));
            return Ok(new { message = result });
        }
        [HttpPut("Activate/{code}")]
        public async Task<IActionResult> ActivateEmployee(string code)
        {
            code = code?.Trim();// to trim the extra space or tabs
            var result = await _mediator.Send(new MakeEmployeeActiveCommand(code));
            return Ok(new { message = result });
        }


    }
}
