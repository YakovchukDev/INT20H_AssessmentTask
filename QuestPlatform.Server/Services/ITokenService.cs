using QuestPlatform.Server.Models;

namespace QuestPlatform.Server.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
        Task<string?> RefreshTokenAsync(string refreshToken);
        string GenerateRefreshToken();
        Task InvalidateUserTokensAsync(int userId);
    }
}
