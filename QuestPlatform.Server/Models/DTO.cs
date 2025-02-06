namespace QuestPlatform.Server.Models
{
    public record RegistrationRequest(string Username, string Nickname, string Email, string AboutMe, string Password, string ConfirmPassword);
    public record LoginRequest(string Email, string Password);
    public record RegisterResponse(bool Success, string Message);
    public record AuthResponse(bool Success, string Token, DateTime Expiration, string Message);
}
