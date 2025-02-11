using QuestPlatform.Server.Models;

namespace QuestPlatform.Server.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
        RefreshToken GenerateRefreshToken(int userId);
        Task InvalidateUserTokensAsync(int userId);
    }
}
