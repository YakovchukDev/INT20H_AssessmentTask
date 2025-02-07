using System.ComponentModel.DataAnnotations;
﻿using QuestPlatform.Server.Enums;

namespace QuestPlatform.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public Role Role { get; set; }
        public string AvatarPath { get; set; }

        public ICollection<Quest> Quests { get; set; }
        public ICollection<QuestRating> Ratings { get; set; }
    }
}
