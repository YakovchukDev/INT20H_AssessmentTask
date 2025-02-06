using Microsoft.AspNetCore.Mvc;
using QuestPlatform.Server.Models;
using QuestPlatform.Server.Services;


namespace QuestPlatform.Server.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly AppDbContext _context;
        public AuthController(AuthService authService, AppDbContext context)
        {
            _authService = authService;
            _context = context;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            var result = await _authService.RegisterUserAsync(request);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authService.LoginUserAsync(request);
            if (!response.Success) return Unauthorized(response.Message);
            return Ok(response);
        }
    }
}
