namespace QuestPlatform.Server.Models
{
    public class TaskOption
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string OptionText { get; set; }

        public QuestTask Task { get; set; }
    }
}
