using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Specializations
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
        public Specialization Specialization { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //La precondicion es que el Project no sea nulo
            Check.Precondition(Specialization != null);
            
            _context.Specialization.Add(Specialization);
            await _context.SaveChangesAsync();

            // La postcondicion es que contenga la especialización luego de agregada
            Check.Postcondition(_context.Specialization.Contains(Specialization)==false);

            return RedirectToPage("./Index");
        }
    }
}