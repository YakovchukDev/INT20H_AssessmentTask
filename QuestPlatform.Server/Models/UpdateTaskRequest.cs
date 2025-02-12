namespace QuestPlatform.Server.Models
{
    public class UpdateTaskRequest
    {
        public int PageId { get; set; }
        public string TaskDescription { get; set; }
        public int ResponseTypeId { get; set; }
        public List<TaskOptionRequest> TaskOptions { get; set; }
    }
}

