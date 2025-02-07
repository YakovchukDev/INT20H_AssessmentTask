namespace QuestPlatform.Server.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int PreviewMediaFileId { get; set; }
        public MediaFile PreviewMediaFile { get; set; }

        public ICollection<Page> Pages { get; set; }
        public ICollection<QuestRating> Ratings { get; set; }
    }
}
