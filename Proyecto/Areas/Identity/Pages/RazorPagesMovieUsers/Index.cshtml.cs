using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Areas.Identity.Data;

namespace RazorPagesMovie.Areas.Identity.Pages.RazorPagesMovieUsers
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Areas.Identity.Data.RazorPagesMovieIdentityDbContext _context;

        public IndexModel(RazorPagesMovie.Areas.Identity.Data.RazorPagesMovieIdentityDbContext context)
        {
            _context = context;
        }

        public IList<RazorPagesMovieUser> RazorPagesMovieUser { get;set; }

        public async Task OnGetAsync()
        {
            RazorPagesMovieUser = await _context.Users.ToListAsync();
        }
    }
}
