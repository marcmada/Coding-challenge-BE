using CoddingChallenge.DTOs;
using CoddingChallenge.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CoddingChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            return Ok(await _loginService.Login(loginDTO));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            return Ok(await _loginService.Register(registerDTO));
        }
    }
}
