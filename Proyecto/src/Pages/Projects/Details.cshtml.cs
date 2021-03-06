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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesContext _context;

        public DetailsModel(RazorPagesMovie.Models.RazorPagesContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.FirstOrDefaultAsync(m => m.ID == id);
            
            // Si el Project es nulo devuelve que no lo encuentra

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
