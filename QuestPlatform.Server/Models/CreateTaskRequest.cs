namespace QuestPlatform.Server.Models
{
    public class CreateTaskRequest
    {
        public string TaskDescription { get; set; }
        public int ResponseTypeId { get; set; }
        public List<TaskOptionRequest> TaskOptions { get; set; }
    }
}
