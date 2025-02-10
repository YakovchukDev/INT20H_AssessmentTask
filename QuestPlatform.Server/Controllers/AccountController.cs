using Microsoft.AspNetCore.Mvc;
using QuestPlatform.Server.Models;
using QuestPlatform.Server.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace QuestPlatform.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            RegisterResponse response = await _accountService.RegisterUserAsync(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            AuthResponse response = await _accountService.LoginUserAsync(request);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            await _accountService.LogoutUserAsync(userId);
            return Ok(new { message = "Вихід успішний" });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            string newToken = await _accountService.RefreshTokenAsync(request.RefreshToken);
            return newToken != null ? Ok(new { token = newToken }) : Unauthorized(new { message = "Недійсний токен" });
        }

        [Authorize]
        [HttpGet("profile/{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            UserResponse profile = await _accountService.GetProfileAsync(id);
            return profile != null ? Ok(profile) : NotFound(new { message = "Профіль не знайдено" });
        }

        [Authorize]
        [HttpPut("profile/update/{id}")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] UserRequest request)
        {
            if (request.UserId != id)
                return Forbid("Ви не можете редагувати чужий профіль");

            bool success = await _accountService.UpdateProfileAsync(id, request);
            return success 
                ? Ok(new { message = "Профіль успішно оновлено" }) 
                : NotFound(new { message = "Помилка оновлення профілю" });
        }
    }
}

