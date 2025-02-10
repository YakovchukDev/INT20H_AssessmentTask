namespace QuestPlatform.Server.Models
{
    public class QuestRatingResponse
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }
        public string Review { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserResponse User { get; set; }
    }
}
