using QuestPlatform.Server.Enums;
using System.ComponentModel.DataAnnotations;

namespace QuestPlatform.Server.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        public string? AboutMe { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public Role Role { get; set; }
        public string? AvatarPath { get; set; }

        public ICollection<Quest> Quests { get; set; }
        public ICollection<QuestRating> Ratings { get; set; }
        public List<UserQuestHistory> UserQuestHistories { get; set; }
    }
}
