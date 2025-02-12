namespace QuestPlatform.Server.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Quest> Quests { get; set; }
    }
}
