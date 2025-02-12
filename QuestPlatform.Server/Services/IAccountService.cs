using QuestPlatform.Server.Models;
using static QuestPlatform.Server.Models.RegistrationRequest;

namespace QuestPlatform.Server.Services
{
    public interface IAccountService
    {
        Task<RegisterResponse> RegisterUserAsync(RegistrationRequest request);
        Task<AuthResponse> LoginUserAsync(LoginRequest request);
        Task LogoutUserAsync(int userId);
        Task<string?> RefreshTokenAsync(string refreshToken);
        Task<UserDTO?> GetProfileAsync(string username);
        Task<bool> UpdateProfileAsync(UserRequest request);
        Task<List<UserQuestHistoryDTO>> GetCompletedQuestsAsync(string username);
        Task<List<CreatedQuestDTO>> GetCreatedQuestsAsync(string username);
    }
}
