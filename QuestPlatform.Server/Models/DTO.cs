namespace QuestPlatform.Server.Models
{
    public record RegistrationRequest(string Name, string Username, string Email, string Password, string ConfirmPassword);
    public record LoginRequest(string Email, string Password);
    public record RegisterResponse(bool Success, string Message);
    public record AuthResponse(bool Success, string Token, DateTime Expiration, string Message);
}
