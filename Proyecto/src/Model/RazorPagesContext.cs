using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Areas.Identity.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Models
{
    public class RazorPagesContext : IdentityDbContext<ApplicationUser>
    {
        public RazorPagesContext (DbContextOptions<RazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Project> Project { get; set; }
        public DbSet<RazorPagesMovie.Models.Project> FinishedProject {get;set;}
        public DbSet<RazorPagesMovie.Models.Technician> Technician { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentSpecialization> AssignmentSpecializations {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assignment>().ToTable("Assignment")
                 .HasKey(a => new { a.TechnicianID, a.ProjectID });
            
            modelBuilder.Entity<AssignmentSpecialization>().ToTable("AssignmentSpecialization")
                 .HasKey(a => new { a.SpecializationID, a.TechnicianID });
        }
        public DbSet<RazorPagesMovie.Models.Specialization> Specialization { get; set; }
    }
}