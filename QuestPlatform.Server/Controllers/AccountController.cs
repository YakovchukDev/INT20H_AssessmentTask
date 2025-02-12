using Microsoft.AspNetCore.Mvc;
using QuestPlatform.Server.Models;
using QuestPlatform.Server.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using static QuestPlatform.Server.Models.RegistrationRequest;
using Microsoft.EntityFrameworkCore;

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
            var newToken = await _accountService.RefreshTokenAsync(request.RefreshToken);
            if (newToken == null)
            {
                return Unauthorized(new { message = "Недійсний токен" });
            }

            return Ok(new { token = newToken });
        }

        [Authorize]
        [HttpGet("profile/{username}")]
        public async Task<IActionResult> GetProfile(string username)
        {
            UserDTO? profile = await _accountService.GetProfileAsync(username);
            return profile != null ? Ok(profile) : NotFound(new { message = "Профіль не знайдено" });
        }

        [Authorize]
        [HttpPut("profile/update")]
        public async Task<IActionResult> UpdateProfile([FromBody] UserRequest request)
        {
            string? authenticatedUsername = User.FindFirst(ClaimTypes.Name)?.Value;

            if (authenticatedUsername == null || authenticatedUsername != request.Username)
                return Unauthorized("Ви не можете редагувати чужий профіль");

            bool success = await _accountService.UpdateProfileAsync(request);
            return success
                ? Ok(new { message = "Профіль успішно оновлено" })
                : NotFound(new { message = "Помилка оновлення профілю" });
        }
    }
}

