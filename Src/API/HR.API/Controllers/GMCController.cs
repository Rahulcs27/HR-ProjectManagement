using HR.Application.Features.GMC.Commands.AddEmpDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    public class GMCController : ControllerBase
    {
       

        private readonly IMediator _mediator;

        public GMCController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddEmpDetailsCommandDto dto)
        {
            var command = new AddEmpDetailsCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Message = "Employee details  added successfully", EmployeeId = id });
        }
       
    }
}
