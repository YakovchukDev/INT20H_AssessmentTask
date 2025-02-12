using Microsoft.AspNetCore.Http;
using QuestPlatform.Server.Enums;

namespace QuestPlatform.Server.Models
{
    public record RegistrationRequest(string Name, string Username, string Email, string Password, string ConfirmPassword);
    public record LoginRequest(string Email, string Password);
    public record RegisterResponse(bool Success, string Message);
    public record AuthResponse(bool Success, string Token, DateTime Expiration, string Message);

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
    public record QuestRequest(TextDTO Title, TextDTO Description, UserDTO Author, IFormFile PreviewMediaFile, int Timer, string Category, int Participants, int Difficulty, HashSet<string> Tags, bool IsPublish, List<PageRequest> Pages);
    public record PageResponse(int PageNumber, string Title, List<PageElementDTO> Elements, TaskDTO Task);
    public record QuestResponse(int Id, TextDTO Title, TextDTO Descriptionx, UserDTO Author, IFormFile PreviewMediaFile, decimal Rating, DateTime CreatedAt, int Timer, string Category, int Participants, int Difficulty, HashSet<string> Tags);

    public record QuestReviewRequest(int QuestId, UserDTO Author, int Rating, string Measege);
    public record QuestReviewsResponse(UserDTO Author, int Rating, string Measege);
}
