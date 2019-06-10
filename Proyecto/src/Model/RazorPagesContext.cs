using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Models
{
    public class RazorPagesContext : DbContext
    {
        public RazorPagesContext (DbContextOptions<RazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Project> Project { get; set; }
        public DbSet<RazorPagesMovie.Models.Technician> Technician { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assignment>().ToTable("Assignment")
                 .HasKey(a => new { a.TechnicianID, a.ProjectID });
        }
    }
}