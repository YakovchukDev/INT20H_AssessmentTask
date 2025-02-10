using QuestPlatform.Server.Models;

namespace QuestPlatform.Server.Services
{
    public interface IAccountService
    {
        Task<RegisterResponse> RegisterUserAsync(RegistrationRequest request);
        Task<AuthResponse> LoginUserAsync(LoginRequest request);
        Task LogoutUserAsync(int userId);
        Task<string?> RefreshTokenAsync(string refreshToken);
        Task<UserResponse?> GetProfileAsync(int userId);
        Task<bool> UpdateProfileAsync(int userId, UserRequest request);
    }

}
