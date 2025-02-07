namespace QuestPlatform.Server.Models
{
    public class UserQuestHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int QuestId { get; set; }
        public Quest Quest { get; set; }
        public TimeSpan TimeSpent { get; set; }
    }
}
