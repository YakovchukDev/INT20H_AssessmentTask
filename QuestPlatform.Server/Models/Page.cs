namespace QuestPlatform.Server.Models
{
    public class Page
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public Quest Quest { get; set; }
        public int PageNumber { get; set; }
        public string Title { get; set; }

        public List<PageElement> PageElements { get; set; }
    }
}
