using QuestPlatform.Server.Enums;

namespace QuestPlatform.Server.Models
{
    public class MediaFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public FileType FileType { get; set; }
    }
}
