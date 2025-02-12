using QuestPlatform.Server.Enums;

namespace QuestPlatform.Server.Models
{
    public class TaskResponseType
    {
        public int Id { get; set; }
        public ResponseType ResponseType { get; set; }
        public string Description { get; set; }
    }
}
