using System.ComponentModel.DataAnnotations;
using QuestPlatform.Server.Enums;

namespace QuestPlatform.Server.Models
{
    public class RegistrationRequest
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; init; }

        [Required, StringLength(50, MinimumLength = 3)]
        public string Username { get; init; }

        [Required, EmailAddress]
        public string Email { get; init; }

        [Required, MinLength(6)]
        public string Password { get; init; }

        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; init; }
    }
    public record LoginRequest(
        [Required, EmailAddress] string Email,
        [Required] string Password
     );

    public record RegisterResponse(bool Success, string Message);

    public record AuthResponse(bool Success, string AccessToken, string RefreshToken, string Message);

    public record RefreshTokenRequest(
        [Required] string AccessToken,
        [Required] string RefreshToken
    );

    public record UserRequest(
        [Required, StringLength(50, MinimumLength = 3)] string Username,
        [Required, StringLength(50, MinimumLength = 3)] string Name,
        [Required, EmailAddress] string Email,
        [Required, MinLength(6)] string Password,
        [Required] string Role,
        string? AboutMe,
        string? AvatarPath
    );

    public record SearchTimer(int Min, int Max);
    public record SearchParticipants(int Min, int Max);
    public record SearchDifficulty(int Min, int Max);
    public record SearchRating(int Min, int Max);
    public record SearchFilter(string Category, SearchTimer Timer, bool NoLimitTimer, SearchParticipants Participants, SearchDifficulty Difficulty, SearchRating Rating, HashSet<string> Tags);

    public record TextDTO(string Text, string Color);
    public record UserDTO(int Id, string Name, string Username);
    public record TaskResponseDTO(string Answer, string AdditionalData);
    public record TaskDTO(string Description, List<string> Option, ResponseType Type);
    public record PageElementDTO(ContentType ContentType, string Content, IFormFile MediaFile, decimal Order);
    public record PageRequest(string Title, List<PageElementDTO> Elements, TaskDTO Task, TaskResponseDTO Response);

    public record QuestRequest(TextDTO Title, TextDTO Description, UserDTO Author, IFormFile PreviewMediaFile, int Timer, string Category, int Participants, int Difficulty, string[] Tags, bool IsPublish, List<PageRequest> Pages);
    public record PageResponse(int PageNumber, string Title, List<PageElementDTO> Elements, TaskDTO Task);
    public record QuestResponse(int Id, TextDTO Title, TextDTO Descriptionx, UserDTO Author, IFormFile PreviewMediaFile, decimal Rating, DateTime CreatedAt, int Timer, string Category, int Participants, int Difficulty, string[] Tags);

    public record QuestReviewRequest(int QuestId, UserDTO Author, int Rating, string Measege);
    public record QuestReviewsResponse(UserDTO Author, int Rating, string Measege);
}
