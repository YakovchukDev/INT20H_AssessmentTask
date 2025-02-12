using QuestPlatform.Server.Enums;

namespace QuestPlatform.Server.Models
{
    public class PageElement
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public ContentType ContentType { get; set; }
        public string Content { get; set; }
        public int? MediaFileId { get; set; }
        public decimal Order {  get; set; }

        public Page Page { get; set; }
        public MediaFile MediaFile { get; set; }
    }
}
