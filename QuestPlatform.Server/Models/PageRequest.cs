namespace QuestPlatform.Server.Models
{
    public class PageRequest
    {
        public int PageNumber { get; set; }
        public string Title { get; set; }
        public List<PageElementRequest> PageElements { get; set; }
        public List<CreateTaskRequest> Tasks { get; set; }
    }
}
