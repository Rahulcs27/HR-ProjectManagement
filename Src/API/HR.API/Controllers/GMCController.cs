using HR.Application.Features.GMC.Commands.AddEmpDetails;
using HR.Application.Features.GMC.Commands.AddFamilyDetails;
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
        [HttpPost("addFamilyDetails")]
        public async Task<IActionResult> AddFamilyDetails([FromBody] AddFamilyDetailsCommandDto dto)
        {
            try
            {
                // Create the command and execute
                var command = new AddFamilyDetailsCommand { FamilyMaster = dto };
                var result = await _mediator.Send(command);

                // Return an appropriate response based on the result
                if (result == null)
                {
                    // If result is null, return a bad request
                    return BadRequest("Failed to add family details.");
                }

                // If everything goes well, return OK with the result
                return Ok(result);
            }
            catch (Exception ex)
            {
                // If an error occurs, catch it and return a BadRequest with the exception message
                return BadRequest(new { message = ex.Message });
            }
        }
    

    }
}
