using LogKeep.Models.AuditLogs;
using Microsoft.EntityFrameworkCore;

namespace LogKeep.Services
{
    public class LogKeepDbContext : DbContext
    {
        public DbSet<Structure> Structures { get; init; }
        public LogKeepDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Structure>();
        }
    }
}
