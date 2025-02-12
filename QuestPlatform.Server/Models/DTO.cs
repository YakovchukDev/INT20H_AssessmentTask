using System.ComponentModel.DataAnnotations;

namespace QuestPlatform.Server.Models
{
    public record RegistrationRequest(
            [Required, StringLength(50, MinimumLength = 3)] string Name,
            [Required, StringLength(50, MinimumLength = 3)] string Username,
            [Required, EmailAddress] string Email,
            [Required, MinLength(6)] string Password,
            string ConfirmPassword,
            string AboutMe,
            string AvatarPath
        )
    {
        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; init; } = ConfirmPassword;
    }

    public record LoginRequest(
        [Required, EmailAddress] string Email,
        [Required] string Password
    );

    public record RegisterResponse(bool Success, string Message, int UserId);

    public record AuthResponse(bool Success, string AccessToken, string RefreshToken, string Message);

    public record RefreshTokenRequest(
        [Required] string AccessToken,
        [Required] string RefreshToken
    );

    public record UserResponse(int Id, string Username, string Name);

    public record UserRequest(
        [Required, StringLength(50, MinimumLength = 3)] string Username,
        [Required, StringLength(50, MinimumLength = 3)] string Name,
        [Required, EmailAddress] string Email,
        [Required, MinLength(6)] string Password,
        [Required] string Role,
        string AboutMe,
        string AvatarPath
    );
}
