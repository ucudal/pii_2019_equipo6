using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Technicians
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesContext _context;

        public CreateModel(RazorPagesMovie.Models.RazorPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Technician Technician { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Technician.hours=0;
            Technician.score=123456789;
            _context.Technician.Add(Technician);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}