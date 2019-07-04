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
            
            _context.Project.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}