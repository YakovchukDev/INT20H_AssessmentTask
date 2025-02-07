namespace QuestPlatform.Server.Models
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public QuestTask Task { get; set; }
        public int ResponseTypeId { get; set; }
        public TaskResponseType ResponseType { get; set; }
        public string Answer {  get; set; }
        public string AdditionalData { get; set; }
    }
}
