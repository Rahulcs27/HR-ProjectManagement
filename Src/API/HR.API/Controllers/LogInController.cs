using HR.Identity.Contracts.Models.Identity;
using HR.Identity.Contracts.Models.Persistence.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    public class LogInController : Controller
    {
        readonly ILoginService _loginService;
        public LogInController(ILoginService loginService)
        {
            _loginService=loginService;
        }

        [HttpPost("Login")]

        public async Task<ActionResult<LoginResponse>>Login(LoginRequest loginRequest)
        {
            var response = await _loginService.Login(loginRequest);
            return Ok(response);
        }
    }
}
