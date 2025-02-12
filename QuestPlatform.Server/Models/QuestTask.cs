using QuestPlatform.Server.Enums;
using System.ComponentModel.DataAnnotations;

namespace QuestPlatform.Server.Models
{
    public class QuestTask
    {
        [Key]
        public int Id { get; set; }
        public int PageId { get; set; }
        public string TaskDescription { get; set; }
        public int ResponseTypeId { get; set; }

        public Page Page { get; set; }
        public TaskResponseType ResponseType { get; set; }
        public List<TaskOption> TaskOptions { get; set; }
    }
}
