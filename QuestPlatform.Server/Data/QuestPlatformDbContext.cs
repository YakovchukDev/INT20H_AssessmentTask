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
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<PageElement> PageElements { get; set; }
        public DbSet<QuestRating> QuestRatings { get; set; }
        public DbSet<QuestTask> Tasks { get; set; }
        public DbSet<TaskOption> TaskOptions { get; set; }
        public DbSet<TaskResponse> TaskResponses { get; set; }
        public DbSet<TaskResponseType> TaskResponseTypes { get; set; }
        public DbSet<UserQuestHistory> UserQuestHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Quest relationships
            modelBuilder.Entity<Quest>()
                .HasOne(q => q.Author)
                .WithMany(u => u.Quests)
                .HasForeignKey(q => q.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.PreviewMediaFile)
                .WithMany()
                .HasForeignKey(q => q.PreviewMediaFileId)
                .OnDelete(DeleteBehavior.Restrict);

            // Page relationships
            modelBuilder.Entity<Page>()
                .HasOne(p => p.Quest)
                .WithMany(q => q.Pages)
                .HasForeignKey(p => p.QuestId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RefreshToken>()
                .Property(rt => rt.Token)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<RefreshToken>()
                .Property(rt => rt.ExpiryDate)
                .IsRequired();


            // PageElement relationships
            modelBuilder.Entity<PageElement>()
                .HasOne(pe => pe.Page)
                .WithMany(p => p.PageElements)
                .HasForeignKey(pe => pe.PageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PageElement>()
                .HasOne(pe => pe.MediaFile)
                .WithMany()
                .HasForeignKey(pe => pe.MediaFileId)
                .OnDelete(DeleteBehavior.SetNull);

            // QuestRating relationships
            modelBuilder.Entity<QuestRating>()
                .HasOne(qr => qr.Quest)
                .WithMany(q => q.Ratings)
                .HasForeignKey(qr => qr.QuestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<QuestRating>()
                .HasOne(qr => qr.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(qr => qr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Enum conversions
            modelBuilder.Entity<MediaFile>()
                .Property(m => m.FileType)
                .HasConversion(
                    m => m.ToString(),
                    m => Enum.Parse<FileType>(m));

            modelBuilder.Entity<PageElement>()
                .Property(pe => pe.ContentType)
                .HasConversion(
                    pe => pe.ToString(),
                    pe => Enum.Parse<ContentType>(pe));

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion(
                    u => u.ToString(),
                    u => Enum.Parse<Role>(u));

            modelBuilder.Entity<TaskResponseType>()
                .Property(trt => trt.ResponseType)
                .HasConversion(
                    trt => trt.ToString(),
                    trt => Enum.Parse<ResponseType>(trt));

            // TaskOption relationships
            modelBuilder.Entity<TaskOption>()
                .HasOne(to => to.Task)
                .WithMany(t => t.TaskOptions)
                .HasForeignKey(to => to.TaskId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
