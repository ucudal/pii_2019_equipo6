using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Models
{
    public class RazorPagesProjectContext : DbContext
    {
        public RazorPagesProjectContext (DbContextOptions<RazorPagesProjectContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Project> Project { get; set; }
    }
}