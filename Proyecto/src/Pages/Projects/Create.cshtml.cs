using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Identity;

namespace RazorPagesMovie.Pages.Projects
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
        public Project Project { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Project.Finished = false;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //La precondicion es que el Project no sea nulo
            Check.Precondition(Project != null);

            _context.Project.Add(Project);
            await _context.SaveChangesAsync();

            // La postcondicion es que se haya agregado el project
            Check.Postcondition(_context.Project.Contains(Project));

            return RedirectToPage("./Index");
        }
    }
}