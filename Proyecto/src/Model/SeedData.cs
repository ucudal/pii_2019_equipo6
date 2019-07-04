using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
                SeedProjects(context);
                SeedSpecialization(context);
            }
        }
        public static void SeedProjects(RazorPagesContext context)
        {
            if (context.Project.Any())
            {
                return;   // DB has been seeded
            }
             //chequeo que el context project no sea nulo
            Check.Precondition (context.Project != null);
            context.Project.AddRange(GetSeedingProjects());
            context.SaveChanges();
        }
        public static List<Project> GetSeedingProjects()
        {
            return new List<Project>()
            {
                new Project
                {
                    Name = "Prueba 1",
                    Description = "its a test",
                    RequiredSpecialization = "Camarografo y Microfonista",
                    Finished = false,
                },
                new Project
                {
                    Name = "Prueba2",
                    Description = "its another test",
                    RequiredSpecialization = "Microfonista",
                    Finished = false,
                }
            };
        }
        public static void SeedSpecialization(RazorPagesContext context)
        {
            if (context.Specialization.Any())
            {
                return;   // DB has been seeded
            }
             //chequeo que el context specialization no sea nulo
            Check.Precondition (context.Specialization != null);
            context.Specialization.AddRange(GetSeedingSpecializations());
            context.SaveChanges();
        }
        public static List<Specialization> GetSeedingSpecializations()
        {
            return new List<Specialization>()
            {
                new Specialization
                {
                    Name = "Camarografo básico",
                    Salary = 30,
                },
                new Specialization
                {
                    Name = "Microfonista básico",
                    Salary = 20,
                },
                    new Specialization
                {
                    Name = "Aguatero básico",
                    Salary = 5,
                },
                    new Specialization
                {
                    Name = "Camarografo avanzado",
                    Salary = 40,
                }
            };
        }
    }
}