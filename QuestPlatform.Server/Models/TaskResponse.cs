using System.ComponentModel.DataAnnotations;

namespace QuestPlatform.Server.Models
{
    public class TaskResponse
    {
        [Key]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int ResponseTypeId { get; set; }
        public string Answer {  get; set; }
        public string? AdditionalData { get; set; }

        public QuestTask Task { get; set; }
        public TaskResponseType Type { get; set; }
    }
}
