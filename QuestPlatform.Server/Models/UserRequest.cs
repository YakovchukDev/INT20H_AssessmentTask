using QuestPlatform.Server.Enums;

namespace QuestPlatform.Server.Models
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string AvatarPath { get; set; }
    }
}
