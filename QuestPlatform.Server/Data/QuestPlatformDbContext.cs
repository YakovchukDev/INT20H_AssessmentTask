using Microsoft.EntityFrameworkCore;
using QuestPlatform.Server.Enums;
using QuestPlatform.Server.Models;
using QuestTask = QuestPlatform.Server.Models.QuestTask;

namespace QuestPlatform.Server.Data
{
    public class QuestPlatformDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageElement> PageElements { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestRating> QuestRatings { get; set; }
        public DbSet<QuestTask> QuestTasks { get; set; }
        public DbSet<QuestText> QuestTexts { get; set; }
        public DbSet<TaskOption> TaskOptions { get; set; }
        public DbSet<TaskResponse> TaskResponses { get; set; }
        public DbSet<TaskResponseType> TaskResponseTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserQuestHistory> UserQuestHistories { get; set; }

        public QuestPlatformDbContext(DbContextOptions<QuestPlatformDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Enum conversion
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (Role)Enum.Parse(typeof(Role), v)
                );

            modelBuilder.Entity<MediaFile>()
                .Property(m => m.FileType)
                .HasConversion(
                    v => v.ToString(),
                    v => (FileType)Enum.Parse(typeof(FileType), v)
                );

            modelBuilder.Entity<PageElement>()
                .Property(p => p.ContentType)
                .HasConversion(
                    v => v.ToString(),
                    v => (ContentType)Enum.Parse(typeof(ContentType), v)
                );

            modelBuilder.Entity<TaskResponseType>()
                .Property(t => t.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (ResponseType)Enum.Parse(typeof(ResponseType), v)
                );

            // Relationships
            modelBuilder.Entity<Page>()
                .HasMany(p => p.PageElements)
                .WithOne(pe => pe.Page)
                .HasForeignKey(pe => pe.PageId);

            modelBuilder.Entity<Quest>()
                .HasMany(q => q.Pages)
                .WithOne(p => p.Quest)
                .HasForeignKey(p => p.QuestId);

            modelBuilder.Entity<PageElement>()
                .HasOne(pe => pe.MediaFile)
                .WithMany()
                .HasForeignKey(pe => pe.MediaFileId);

            modelBuilder.Entity<QuestTask>()
                .HasOne(qt => qt.Page)
                .WithMany()
                .HasForeignKey(qt => qt.PageId);

            modelBuilder.Entity<QuestTask>()
                .HasOne(qt => qt.ResponseType)
                .WithMany()
                .HasForeignKey(qt => qt.ResponseTypeId);

            modelBuilder.Entity<TaskOption>()
                .HasOne(to => to.Task)
                .WithMany()
                .HasForeignKey(to => to.TaskId);

            modelBuilder.Entity<TaskResponse>()
                .HasOne(tr => tr.Task)
                .WithMany()
                .HasForeignKey(tr => tr.TaskId);

            modelBuilder.Entity<TaskResponse>()
                .HasOne(tr => tr.Type)
                .WithMany()
                .HasForeignKey(tr => tr.ResponseTypeId);

            // New relationships
            modelBuilder.Entity<UserQuestHistory>()
                .HasOne(uh => uh.User)
                .WithMany(u => u.UserQuestHistories)
                .HasForeignKey(uh => uh.UserId);

            modelBuilder.Entity<Quest>()
                .HasMany(q => q.QuestRatings)
                .WithOne(qr => qr.Quest)
                .HasForeignKey(qr => qr.QuestId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Quests)
                .WithOne(q => q.Author)
                .HasForeignKey(q => q.AuthorId);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.PreviewMediaFile)
                .WithOne()
                .HasForeignKey<Quest>(q => q.PreviewMediaFileId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.Title)
                .WithMany()
                .HasForeignKey(q => q.TitleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.Description)
                .WithMany()
                .HasForeignKey(q => q.DescriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.Category)
                .WithMany()
                .HasForeignKey(q => q.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.Author)
                .WithMany(u => u.Quests)
                .HasForeignKey(q => q.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quest>()
                .HasMany(q => q.Pages)
                .WithOne(p => p.Quest)
                .HasForeignKey(p => p.QuestId);

            modelBuilder.Entity<PageElement>()
                .HasOne(pe => pe.MediaFile)
                .WithMany()
                .HasForeignKey(pe => pe.MediaFileId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<QuestRating>()
                .HasOne(qr => qr.Quest)
                .WithMany(q => q.QuestRatings)
                .HasForeignKey(qr => qr.QuestId);

            modelBuilder.Entity<QuestRating>()
                .HasOne(qr => qr.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(qr => qr.UserId);

            modelBuilder.Entity<Quest>()
                .Property(q => q.AuthorId)
                .HasColumnType("integer");
        }
    }
}