using QuestPlatform.Server.Enums;

namespace QuestPlatform.Server.Models
{
    public class QuestTask
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public Page Page { get; set; }
        public string TaskDescription { get; set; }
        public int ResponseTypeId { get; set; }
        public TaskResponseType ResponseType { get; set; }

        public ICollection<TaskOption> TaskOptions { get; set; }
    }
}
