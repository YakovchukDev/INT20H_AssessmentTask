namespace QuestPlatform.Server.Models
{
    public record RegistrationRequest(string Name, string Username, string Email, string Password, string ConfirmPassword, string AboutMe, string AvatarPath);
    public record LoginRequest(string Email, string Password);
    public record RegisterResponse(bool Success, string Message, int UserId);
    public record AuthResponse(bool Success, string AccessToken, string RefreshToken, string Message);
    public record RefreshTokenRequest(string AccessToken, string RefreshToken);
    public record UserResponse(int Id, string Username, string Name);
    public record UserRequest(string Username, string Name, string Email, string Password, string Role, string AboutMe, string AvatarPath);
}
