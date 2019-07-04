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
        public async void OnPostSaveAsync(int id, int TechnicianToUpdateID, int param1, int param2)
        {
        if (param2 >= 1 && param2 <= 5)
            {                
            Projects = await _context.Project.ToListAsync();

            Project = await _context.Project
            .Where(m => m.ID == id)
            .Include(c =>c.Assignments)
            .ThenInclude(a => a.Technician)
            .FirstOrDefaultAsync();

            this.Technicians = Project.Assignments
            .Select(a => a.Technician);


            Technician ProjectToUpdate = await _context.Technician
                .Include(a => a.Assignments)
                    .ThenInclude(a => a.Technician)
                .FirstOrDefaultAsync(m => m.ID == TechnicianToUpdateID);

            await TryUpdateModelAsync<Technician>(ProjectToUpdate);

                //Por alguna razón el framework en algunos casos modifica el id del técnico a 1 en el
                //TryUpdateModelAsync haciendo que crashee cuando va a gurdar los cambios, la siguiente
                //linea puede parecer fuera de lugar pero es la solución que encontré.
                ProjectToUpdate.ID = TechnicianToUpdateID;
            
                ProjectToUpdate.hours = ProjectToUpdate.hours + param1;
    
                if (ProjectToUpdate.score != 0)
                {
                    ProjectToUpdate.score = (ProjectToUpdate.score + param2)/2;
                }
                else
                {
                    ProjectToUpdate.score = param2;
                }
            
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IActionResult> OnPostFinishAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.FindAsync(id);

            if (Project != null)
            {
                _context.FinishedProject.Add(Project);
                _context.Project.Remove(Project);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}