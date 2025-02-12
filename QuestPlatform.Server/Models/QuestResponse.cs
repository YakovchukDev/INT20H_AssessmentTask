namespace QuestPlatform.Server.Models
{
    public class QuestResponse
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public PageResponse Page { get; set; }
        public int TaskId { get; set; }
        public int ResponseTypeId { get; set; }
        public string Response { get; set; }
    }
}
