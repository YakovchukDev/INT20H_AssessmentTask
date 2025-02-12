using QuestPlatform.Server.Enums;
using System.ComponentModel.DataAnnotations;

namespace QuestPlatform.Server.Models
{
    public class MediaFile
    {
        [Key]
        public int Id { get; set; }
        public string FilePath { get; set; }
        public FileType FileType { get; set; }
    }
}
