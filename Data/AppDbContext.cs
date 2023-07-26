namespace PhasmophobiaDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using PhasmophobiaDatabase.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Ghost> Ghosts { get; set; }
        public DbSet<Evidence> Evidence { get; set; }
        public DbSet<Speed> Speed { get; set; }
        public DbSet<SanityThreshold> SanityThreshold { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evidence>()
                .HasOne(e => e.Ghost)
                .WithMany(g => g.Evidence)
                .HasForeignKey(e => e.GhostId);

            modelBuilder.Entity<Speed>()
                .HasOne(s => s.Ghost)
                .WithMany(g => g.Speed)
                .HasForeignKey(s => s.GhostId);

            modelBuilder.Entity<SanityThreshold>()
                .HasOne(st => st.Ghost)
                .WithMany(g => g.SanityThreshold)
                .HasForeignKey(st => st.GhostId);
        }
    }


}
