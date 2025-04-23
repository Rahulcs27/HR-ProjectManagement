using HR.Application.Contracts.Models;
using HR.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;   
        }

        [HttpPost("login")]

        public async Task<ActionResult<LoginResponse>>Login(LoginRequest loginRequest)
        {
            var response=await _loginService.Login(loginRequest);
            return Ok(response);
        }
    }
}
