using QuestPlatform.Server.Enums;

namespace QuestPlatform.Server.Models
{
    public class QuestTask
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public string TaskDescription { get; set; }
        public int ResponseTypeId { get; set; }

        public Page Page { get; set; }
        public TaskResponseType TaskResponseType { get; set; }
        public TaskResponse TaskResponse { get; set; }
        public List<TaskOption> TaskOptions { get; set; }
    }
}
