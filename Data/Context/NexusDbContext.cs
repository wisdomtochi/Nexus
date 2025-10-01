using Microsoft.EntityFrameworkCore;
using Nexus.Entities;

namespace Nexus.Data.Context
{
    public class NexusDbContext : DbContext
    {
        public NexusDbContext(DbContextOptions<NexusDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
