using HR.Application.Features.TimeSheet.Commands.CreateTimeSheet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetController : ControllerBase
    {
        readonly IMediator _meditor;
        public TimeSheetController(IMediator mediator)
        {

            _meditor = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddTimeSheet([FromBody] AddTimeSheetCommand request)
        {

            var response = await _meditor.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult get()
        {
            var response = new { Name = "sakshi", Age = 22 };
            return Ok(response);
        }
    }
}
