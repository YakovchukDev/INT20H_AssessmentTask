using System.ComponentModel.DataAnnotations;

namespace QuestPlatform.Server.Models
{
    public class Page
    {
        [Key]
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int PageNumber { get; set; }
        public string Title { get; set; }

        public Quest Quest { get; set; }
        public List<PageElement> PageElements { get; set; }
    }
}
