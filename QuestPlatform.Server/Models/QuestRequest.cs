namespace QuestPlatform.Server.Models
{
    public class QuestRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int PreviewMediaFileId { get; set; }
        public TimeSpan? Timer { get; set; }
        public List<PageRequest> Pages { get; set; }
    }
}

