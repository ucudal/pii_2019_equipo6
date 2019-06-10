using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesContext>>()))
            {
                if (context.Project.Any())
                {
                    return;   // DB has been seeded
                }
                 //chequeo que el context project no sea nulo
                Check.Precondition (context.Project != null);
                context.Project.AddRange(
                    new Project
                    {
                        Name = "Mariana",
                        Description = "Crack",
                        RequiredSpecialization = "Tecnica",
                    }

                    
                );
                context.SaveChanges();
            }
        }
    }
}