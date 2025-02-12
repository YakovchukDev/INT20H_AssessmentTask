namespace QuestPlatform.Server.Models
{
    public class QuestRatingRequest
    {
        public int UserId { get; set; }
        public decimal Rating { get; set; }
        public string Review { get; set; }
    }
}

