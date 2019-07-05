using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Technicians
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesContext _context;

        public EditModel(RazorPagesMovie.Models.RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Technician Technician { get; set; }
        public IEnumerable<Specialization> Specializations {get;set;}
        public IEnumerable<Specialization> AllSpecializations { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Technician = await _context.Technician
            .Where(m => m.ID == id)
            .Include(c =>c.AssignmentSpecializations)
            .ThenInclude(a => a.Specialization)
            .FirstOrDefaultAsync();

            if (Technician == null)
            {
                return NotFound();
            }
            
            // Populate the list of actors in the viewmodel with the actors of the movie.
            this.Specializations = Technician.AssignmentSpecializations
                .Select(a => a.Specialization);

            string nameFilter = "";
            if (this.SearchString != null)
            {
                nameFilter = this.SearchString.ToUpper();
            }

            // Populate the list of all other actors with all actors not included in the movie's actors and
            // included in the search filter.
            this.AllSpecializations = await _context.Specialization
                .Where(a =>!Specializations.Contains(a))
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

            _context.Attach(Technician).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicianExists(Technician.ID))
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
            public async Task<IActionResult> OnPostDeleteSpecializationAsync(int id, int SpecializationToDeleteID)
        {
            Specialization TechnicianToUpdate = await _context.Specialization
                .Include(a => a.AssignmentSpecializations)
                    .ThenInclude(a => a.Specialization)
                .FirstOrDefaultAsync(m => m.ID == id);

            await TryUpdateModelAsync<Specialization>(TechnicianToUpdate);

            var specializationToDelete = TechnicianToUpdate.AssignmentSpecializations.Where(a => a.SpecializationID == SpecializationToDeleteID).FirstOrDefault();
            if (specializationToDelete != null)
            {
                TechnicianToUpdate.AssignmentSpecializations.Remove(specializationToDelete);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicianExists(Technician.ID))
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
        public async Task<IActionResult> OnPostAddSpecializationAsync(int? id, int? specializationToAddID)
        {
            Technician technicianToUpdate = await _context.Technician
                .Include(a => a.AssignmentSpecializations)
                    .ThenInclude(a => a.Specialization)
                .FirstOrDefaultAsync(m => m.ID == Technician.ID);

            await TryUpdateModelAsync<Technician>(technicianToUpdate);


            if (specializationToAddID != null)
            {
                Specialization specializationToAdd = await _context.Specialization.Where(a => a.ID == specializationToAddID).FirstOrDefaultAsync();
                if (specializationToAdd != null)
                {
                    var assignmentSpecializationToAdd = new AssignmentSpecialization() {
                        SpecializationID = specializationToAddID.Value,
                        Specialization = specializationToAdd,
                        TechnicianID = technicianToUpdate.ID,
                        Technician = technicianToUpdate };
                    technicianToUpdate.AssignmentSpecializations.Add(assignmentSpecializationToAdd);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicianExists(Technician.ID))
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

        private bool TechnicianExists(int id)
        {
            return _context.Technician.Any(e => e.ID == id);
        }
    }
}
