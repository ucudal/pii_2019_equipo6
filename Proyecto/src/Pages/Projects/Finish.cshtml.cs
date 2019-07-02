using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Projects
{

/*FinishModel hereda de PageModel que es una clase que tiene propiedades propias de RazorPages que permiten
trabajar con las solicitudes http y tiene métodos que permiten especificar el tipo de respuesta */ 
    public class FinishModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesContext _context;

        public FinishModel(RazorPagesMovie.Models.RazorPagesContext context)
        {
            _context = context;
        }
        public IList<Project> Projects { get;set; }
        [BindProperty]
        public Project Project { get; set; }
        public IEnumerable<Technician> Technicians {get;set;}
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            Projects = await _context.Project.ToListAsync();

            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project
            .Where(m => m.ID == id)
            .Include(c =>c.Assignments)
            .ThenInclude(a => a.Technician)
            .FirstOrDefaultAsync();

            this.Technicians = Project.Assignments
            .Select(a => a.Technician);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}