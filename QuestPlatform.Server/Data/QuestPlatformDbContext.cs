using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuestPlatform.Server.Enums;
using QuestPlatform.Server.Models;
using QuestTask = QuestPlatform.Server.Models.QuestTask;

namespace QuestPlatform.Server.Data
{
    public class QuestPlatformDbContext : DbContext
    {
        public QuestPlatformDbContext(DbContextOptions<QuestPlatformDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<PageElement> PageElements { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<QuestRating> QuestRatings { get; set; }
        public DbSet<QuestTask> QuestTasks { get; set; }
        public DbSet<QuestText> QuestTexts { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<TaskOption> TaskOptions { get; set; }
        public DbSet<TaskResponseType> TaskResponseTypes { get; set; }
        public DbSet<TaskResponse> TaskResponses { get; set; }
        public DbSet<UserQuestHistory> UserQuestHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.Category)
                .WithMany(c => c.Quests)
                .HasForeignKey(q => q.CategoryId);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.PreviewMediaFile)
                .WithMany()
                .HasForeignKey(q => q.PreviewMediaFileId);

            modelBuilder.Entity<PageElement>()
                .HasOne(pe => pe.Page)
                .WithMany(p => p.PageElements)
                .HasForeignKey(pe => pe.PageId);

            modelBuilder.Entity<PageElement>()
                .HasOne(pe => pe.MediaFile)
                .WithMany()
                .HasForeignKey(pe => pe.MediaFileId);

            modelBuilder.Entity<QuestRating>()
                .HasOne(qr => qr.Quest)
                .WithMany(q => q.QuestRatings)
                .HasForeignKey(qr => qr.QuestId);

            modelBuilder.Entity<QuestRating>()
                .HasOne(qr => qr.User)
                .WithMany(u => u.QuestRatings)
                .HasForeignKey(qr => qr.UserId);

            modelBuilder.Entity<QuestTask>()
                .HasOne(qt => qt.Page)
                .WithMany(p => p.QuestTasks)
                .HasForeignKey(qt => qt.PageId);

            modelBuilder.Entity<QuestTask>()
                .HasOne(qt => qt.TaskResponseType)
                .WithMany()
                .HasForeignKey(qt => qt.ResponseTypeId);

            modelBuilder.Entity<TaskResponse>()
                .HasOne(tr => tr.Task)
                .WithOne(t => t.TaskResponse)
                .HasForeignKey<TaskResponse>(tr => tr.TaskId);

            modelBuilder.Entity<TaskResponse>()
                .HasOne(tr => tr.ResponseType)
                .WithMany()
                .HasForeignKey(tr => tr.ResponseTypeId);

            modelBuilder.Entity<UserQuestHistory>()
                .HasOne(uh => uh.User)
                .WithMany(u => u.UserQuestHistories)
                .HasForeignKey(uh => uh.UserId);

            modelBuilder.Entity<UserQuestHistory>()
                .HasOne(uh => uh.Quest)
                .WithMany(q => q.UserQuestHistories)
                .HasForeignKey(uh => uh.QuestId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.QuestRatings)
                .WithOne(qr => qr.User)
                .HasForeignKey(qr => qr.UserId);

            modelBuilder.Entity<MediaFile>()
                .Property(e => e.FileType)
                .HasConversion(
                    v => v.ToString(),
                    v => (FileType)Enum.Parse(typeof(FileType), v)
                );
            modelBuilder.Entity<PageElement>()
                .Property(e => e.ContentType)
                .HasConversion(
                    v => v.ToString(),
                    v => (ContentType)Enum.Parse(typeof(ContentType), v)
                );
            modelBuilder.Entity<TaskResponseType>()
                .Property(e => e.ResponseType)
                .HasConversion(
                    v => v.ToString(),
                    v => (ResponseType)Enum.Parse(typeof(ResponseType), v)
                );
            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (Role)Enum.Parse(typeof(Role), v)
                );
        }
    }
}
