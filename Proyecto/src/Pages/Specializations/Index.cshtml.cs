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
    //IndexModel Hereda de PageModel por motivos que ya explicamos, vemos nuevamente herencia.
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesContext _context;

        public IndexModel(RazorPagesMovie.Models.RazorPagesContext context)
        {
            _context = context;
        }

        public IList<Specialization> Specialization { get;set; }

        public async Task OnGetAsync()
        {
            Specialization = await _context.Specialization.ToListAsync();
        }
    }
}
