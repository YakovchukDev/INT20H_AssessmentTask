using Microsoft.EntityFrameworkCore;
using QuestPlatform.Server.Models;

namespace QuestPlatform.Server
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
