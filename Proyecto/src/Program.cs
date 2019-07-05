using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Models;
using System;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Areas.Identity.Data;

namespace RazorPagesMovie
{

/* En nuestro programa contamos con bajo acoplamiento, hay baja dependencia reutilizamos codigo para esto.
Tenemos también alta cohesión, asignamos las responsabilidades de forma tal que esto se cumpla.*/

/* Se cumple ISP, va de la mano del bajo acoplamiento. No se depende de interfaces que no se usan */

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                
// Se arroja una excepción si no puede iniciar los servicios con la Base de datos 
                try
                {
                    var context=services.
                        GetRequiredService<RazorPagesContext>();
                    context.Database.Migrate();
                    SeedData.Initialize(services);
                    SeedIdentityData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}