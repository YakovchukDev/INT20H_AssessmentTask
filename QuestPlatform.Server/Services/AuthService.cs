using QuestPlatform.Server.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;



namespace QuestPlatform.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<RegisterResponse> RegisterUserAsync(RegistrationRequest request)
        {
            if (request.Password != request.ConfirmPassword)
                return new RegisterResponse(false, "Паролі не співпадають");
            if (request.Password.Length < 6)
                return new RegisterResponse(false, "Пароль має містити мінімум 6 символів");
            if (!new EmailAddressAttribute().IsValid(request.Email))
                return new RegisterResponse(false, "Невірний формат email");
            if (await _context.Users.AnyAsync(user => user.Email == request.Email || user.Nickname == request.Nickname))
                return new RegisterResponse(false, "Користувач з таким email або нікнеймом вже існує");
            var user = new User
            {
                Username = request.Username,
                Nickname = request.Nickname,
                AboutMe = request.AboutMe,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new RegisterResponse(true, "Реєстрація успішна");
        }
        public async Task<AuthResponse> LoginUserAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return new AuthResponse(false, null, DateTime.MinValue, "Невірний email або пароль");

            var token = GenerateJwtToken(user);
            var authResponse = new AuthResponse(true, token, DateTime.UtcNow.AddHours(2), "Авторизація успішна");
            return authResponse;
        }
        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
