using QuestPlatform.Server.Models;

namespace QuestPlatform.Server.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterUserAsync(RegistrationRequest request);
        Task<AuthResponse> LoginUserAsync(LoginRequest request);
    }

}
