using System.ComponentModel.DataAnnotations;

namespace QuestPlatform.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Nickname { get; set; }
        public required string AboutMe { get; set; }
        public required string PasswordHash { get; set; }
    }
}
