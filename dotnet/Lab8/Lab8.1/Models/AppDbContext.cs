using Microsoft.EntityFrameworkCore;

namespace EFExample.Models
{
    // Custom DbContext class
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // GPA precision/scale (avoids EF warm about decimal truncation)
            modelBuilder.Entity<Student>()
                .Property(s => s.GPA)
                .HasPrecision(3, 2);
        }
    }
}