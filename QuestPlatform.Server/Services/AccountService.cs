using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using QuestPlatform.Server.Data;
using QuestPlatform.Server.Enums;
using QuestPlatform.Server.Models;
using static QuestPlatform.Server.Models.RegistrationRequest;

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
                return new RegisterResponse(false, "Користувач із такою поштою вже існує");
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
                return new RegisterResponse(false, "Користувач із таким Username існує");

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
            return new RegisterResponse(true, "Реєстрація успішна");
        }

        public async Task<AuthResponse> LoginUserAsync(LoginRequest request)
        {
            User? user = await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return new AuthResponse(false, string.Empty, string.Empty, "Невірний email або пароль");
            }

            string accessToken = _tokenService.GenerateJwtToken(user);
            RefreshToken refreshToken = _tokenService.GenerateRefreshToken(user.Id);

            user.RefreshTokens ??= new List<RefreshToken>();
            user.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthResponse(true, accessToken, refreshToken.Token, "Авторизація успішна");
        }

        public async Task LogoutUserAsync(int userId)
        {
            await _tokenService.InvalidateUserTokensAsync(userId);
        }

        public async Task<string?> RefreshTokenAsync(string refreshToken)
        {
            var token = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == refreshToken);
            if (token == null || token.ExpiryDate < DateTime.UtcNow)
            {
                return null;
            }

            User? user = await _context.Users.FindAsync(token.UserId);
            return user != null ? _tokenService.GenerateJwtToken(user) : null;
        }

        public async Task<UserDTO?> GetProfileAsync(string username)
        {
            User? user = await _context.Users
                .Include(u => u.Quests)
                .Include(u => u.Ratings)
                .FirstOrDefaultAsync(u => u.Username == username);

            return user == null ? null : new UserDTO(user.Id, user.Username, user.Name);
        }

        public async Task<bool> UpdateProfileAsync(UserRequest request)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null) return false;
            bool emailExists = await _context.Users.AnyAsync(u => u.Email == request.Email && u.Id != user.Id);
            if (emailExists) return false;
            user.Name = request.Name;
            user.Email = request.Email;
            if (request.AboutMe != null)
            {
                user.AboutMe = request.AboutMe;
            }
            if (request.AvatarPath != null)
            {
                user.AvatarPath = request.AvatarPath;
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserQuestHistoryDTO>> GetCompletedQuestsAsync(string username)
        {
            User? user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return new List<UserQuestHistoryDTO>();

            return await _context.UserQuestHistories
                .Where(qh => qh.UserId == user.Id)
                .Select(qh => new UserQuestHistoryDTO(
                    qh.Quest.Id,
                    qh.Quest.Title,
                    qh.Status,
                    qh.TimeSpent,
                    qh.Step
                ))
                .ToListAsync();
        }

        public async Task<List<CreatedQuestDTO>> GetCreatedQuestsAsync(string username)
        {
            User? user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return new List<CreatedQuestDTO>();

            return await _context.Quests
                .Where(q => q.AuthorId == user.Id)
                .Select(q => new CreatedQuestDTO(q.Id, q.Title, q.CreatedAt))
                .ToListAsync();
        }
    }
}

