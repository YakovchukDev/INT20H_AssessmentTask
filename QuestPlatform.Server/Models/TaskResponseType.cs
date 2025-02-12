using QuestPlatform.Server.Enums;
using System.ComponentModel.DataAnnotations;

namespace QuestPlatform.Server.Models
{
    public class TaskResponseType
    {
        [Key]
        public int Id { get; set; }
        public ResponseType Type { get; set; }
    }
}
