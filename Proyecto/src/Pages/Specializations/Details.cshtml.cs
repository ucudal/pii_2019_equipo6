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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesContext _context;

        public DetailsModel(RazorPagesMovie.Models.RazorPagesContext context)
        {
            _context = context;
        }

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
    }
}
