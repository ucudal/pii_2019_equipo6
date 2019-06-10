using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesContext _context;

        public EditModel(RazorPagesMovie.Models.RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }
        public IEnumerable<Technician> Technicians {get;set;}
        public IEnumerable<Technician> AllTechnicians { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project
            .Where(m => m.ID == id)
            .Include(c =>c.Assignments)
            .ThenInclude(a => a.Technician)
            .FirstOrDefaultAsync();

            if (Project == null)
            {
                return NotFound();
            }
            // Populate the list of actors in the viewmodel with the actors of the movie.
            this.Technicians = Project.Assignments
                .Select(a => a.Technician);

            string nameFilter = "";
            if (this.SearchString != null)
            {
                nameFilter = this.SearchString.ToUpper();
            }

            // Populate the list of all other actors with all actors not included in the movie's actors and
            // included in the search filter.
            this.AllTechnicians = await _context.Technician
                .Where(a =>!Technicians.Contains(a))
                .Where(a => !string.IsNullOrEmpty(nameFilter) ? a.Name.ToUpper().Contains(nameFilter) : true)
                .ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

            public async Task<IActionResult> OnPostDeleteTechnicianAsync(int id, int TechnicianToDeleteID)
        {
            Technician ProjectToUpdate = await _context.Technician
                .Include(a => a.Assignments)
                    .ThenInclude(a => a.Technician)
                .FirstOrDefaultAsync(m => m.ID == id);

            await TryUpdateModelAsync<Technician>(ProjectToUpdate);

            var technicianToDelete = ProjectToUpdate.Assignments.Where(a => a.TechnicianID == TechnicianToDeleteID).FirstOrDefault();
            if (technicianToDelete != null)
            {
                ProjectToUpdate.Assignments.Remove(technicianToDelete);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Redirect(Request.Path + $"?id={id}");
        }
        public async Task<IActionResult> OnPostAddTechnicianAsync(int? id, int? technicianToAddID)
        {
            Project projectToUpdate = await _context.Project
                .Include(a => a.Assignments)
                    .ThenInclude(a => a.Technician)
                .FirstOrDefaultAsync(m => m.ID == Project.ID);

            await TryUpdateModelAsync<Project>(projectToUpdate);


            if (technicianToAddID != null)
            {
                Technician technicianToAdd = await _context.Technician.Where(a => a.ID == technicianToAddID).FirstOrDefaultAsync();
                if (technicianToAdd != null)
                {
                    var assignmentToAdd = new Assignment() {
                        TechnicianID = technicianToAddID.Value,
                        Technician = technicianToAdd,
                        ProjectID = projectToUpdate.ID,
                        Project = projectToUpdate };
                    projectToUpdate.Assignments.Add(assignmentToAdd);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect(Request.Path + $"?id={id}");
        }
        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ID == id);
        }
    }
}
