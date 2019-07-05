using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Specializations
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesContext _context;

        public DeleteModel(RazorPagesMovie.Models.RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Specialization Specialization { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Specialization = await _context.Specialization.FirstOrDefaultAsync(m => m.ID == id);

            if (Specialization == null)
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

            Specialization = await _context.Specialization.FindAsync(id);

            if (Specialization != null)
            {
                // La precondicion es que _context.Specialization contenga Specialization para poder eliminarla.
                Check.Precondition(_context.Specialization.Contains(Specialization));

                _context.Specialization.Remove(Specialization);
                await _context.SaveChangesAsync();

                // La postcondicion es que se haya eliminado la especialización
                Check.Postcondition(_context.Specialization.Contains(Specialization)==false);
            }

            return RedirectToPage("./Index");
        }
    }
}
