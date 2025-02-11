using Microsoft.EntityFrameworkCore;
using QuestPlatform.Server.Data;
using QuestPlatform.Server.Enums;
using QuestPlatform.Server.Models;

namespace QuestPlatform.Server.Services
{
    public class AccountService : IAccountService
    {
        private readonly QuestPlatformDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly TokenService _tokenService;

        public AccountService(QuestPlatformDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _tokenService = new TokenService(context, configuration);
        }

        public async Task<RegisterResponse> RegisterUserAsync(RegistrationRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
                return new RegisterResponse(false, "Користувач із такою поштою вже існує", 0);

            User? newUser = new User
            {
                Name = request.Name,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = Role.User,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return new RegisterResponse(true, "Реєстрація успішна", newUser.Id);
        }

        public async Task<AuthResponse> LoginUserAsync(LoginRequest request)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return new AuthResponse(false, string.Empty, string.Empty,  "Невірний email або пароль");

            string accessToken = _tokenService.GenerateJwtToken(user);
            string refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;

            return new AuthResponse(true, accessToken, refreshToken, "Авторизація успішна");
        }

        public async Task LogoutUserAsync(int userId)
        {
            await _tokenService.InvalidateUserTokensAsync(userId);
        }

        public async Task<string?> RefreshTokenAsync(string refreshToken)
        {
            return await _tokenService.RefreshTokenAsync(refreshToken);
        }

        public async Task<UserResponse?> GetProfileAsync(string username)
        {
            User? user = await _context.Users
                .Include(u => u.Quests)
                .Include(u => u.Ratings)
                .FirstOrDefaultAsync(u => u.Username == username);

            return user == null ? null : new UserResponse
            {
                UserId = user.Id,
                Username = user.Username,
                Name = user.Name,
            };
        }

        public async Task<bool> UpdateProfileAsync(UserRequest request)
        {
            User? user = await _context.Users.FindAsync(request.Username);
            if (user == null) return false;
            bool emailExists = await _context.Users.AnyAsync(u => u.Email == request.Email && u.Id != user.Id);
            if (emailExists) return false;
            user.Name = request.Name;
            user.Email = request.Email;
            user.AboutMe aboutMe = request.AboutMe;
            user.AvatarPath = request.AvatarPath;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

