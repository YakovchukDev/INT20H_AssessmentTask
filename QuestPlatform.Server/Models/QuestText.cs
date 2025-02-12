using System.ComponentModel.DataAnnotations;

namespace QuestPlatform.Server.Models
{
    public class QuestText
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
    }
}
