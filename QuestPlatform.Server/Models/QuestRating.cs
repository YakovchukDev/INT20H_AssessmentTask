namespace QuestPlatform.Server.Models
{
    public class QuestRating
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public Quest Quest { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
