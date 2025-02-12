using System.ComponentModel.DataAnnotations;

namespace QuestPlatform.Server.Models
{
    public class QuestRating
    {
        [Key]
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int UserId { get; set; }
        public int? Rating { get; set; }
        public string Review { get; set; }
        public Quest Quest { get; set; }
        public User User { get; set; }
    }
}
