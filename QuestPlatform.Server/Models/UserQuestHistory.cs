using QuestPlatform.Server.Enums;
using System.ComponentModel.DataAnnotations;

namespace QuestPlatform.Server.Models
{
    public class UserQuestHistory
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestId { get; set; }
        public QuestStatus Status { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public int Step { get; set; }

        public User User { get; set; }
        public Quest Quest { get; set; }
    }
}
