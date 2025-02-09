namespace QuestPlatform.Server.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int DescriptionId { get; set; }
        public int AuthorId { get; set; }
        public decimal? Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int PreviewMediaFileId { get; set; }
        public TimeSpan? Timer { get; set; }
        public int CategoryId { get; set; }
        public int Participants { get; set; }
        public int Difficulty { get; set; }
        public string[] Tags { get; set; }

        public QuestText Title { get; set; }
        public QuestText Description { get; set; }
        public User Author { get; set; }
        public MediaFile PreviewMediaFile { get; set; }
        public Category Category { get; set; }
        public List<QuestRating> QuestRatings { get; set; }
        public List<UserQuestHistory> UserQuestHistories { get; set; }
    }
}
