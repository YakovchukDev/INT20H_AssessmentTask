using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuestPlatform.Server.Data;
using QuestPlatform.Server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace QuestPlatform.Server.Services
{
    public class TokenService : ITokenService
    {
        private readonly QuestPlatformDbContext _context;
        private readonly IConfiguration _configuration;

        public TokenService(QuestPlatformDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string GenerateJwtToken(User user)
        {
            byte[] key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken(int userId)
        {
            byte[] randomBytes = new byte[32];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                UserId = userId,
                ExpiryDate = DateTime.UtcNow.AddDays(7)
            };
        }

        public async Task InvalidateUserTokensAsync(int userId)
        {
            var tokens = await _context.RefreshTokens.Where(t => t.UserId == userId).ToListAsync();
            if (tokens.Any())
            {
                _context.RefreshTokens.RemoveRange(tokens);
                await _context.SaveChangesAsync();
            }
        }
    }
}
