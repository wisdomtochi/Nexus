using Microsoft.EntityFrameworkCore;
using Nexus.Entities;

namespace Nexus.Data.Context
{
    public class NexusDbContext : DbContext
    {
        public NexusDbContext(DbContextOptions<NexusDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<ChatUser> ChatUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChatUser>().HasData(
                new ChatUser
                {
                    Id = Guid.NewGuid(),
                    Name = "System",
                    Message = "Welcome to the chat!",
                    UserId = "system",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
