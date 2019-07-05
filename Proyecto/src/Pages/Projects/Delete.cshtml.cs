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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesContext _context;

        public DeleteModel(RazorPagesMovie.Models.RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.FirstOrDefaultAsync(m => m.ID == id);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.FindAsync(id);

            if (Project != null)
            {
                // La precondicion es que _context.Project contenga Project para poder eliminarlo.
                Check.Precondition(_context.Project.Contains(Project));
                _context.Project.Remove(Project);
                await _context.SaveChangesAsync();
                // La postcondicion es que se haya eliminado el Project
                Check.Postcondition(_context.Project.Contains(Project)==false);
            }

            return RedirectToPage("./Index");
        }
    }
}