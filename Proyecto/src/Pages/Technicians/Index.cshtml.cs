using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Technicians
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesContext _context;

        public IndexModel(RazorPagesMovie.Models.RazorPagesContext context)
        {
            _context = context;
        }

        public IList<Technician> Technician { get;set; }

        public async Task OnGetAsync()
        {
            Technician = await _context.Technician.ToListAsync();
            ErrorChecker();
        }

        public void ErrorChecker()
        {
            foreach(var item in Technician)
            {
                if(item.hours<0)
                {
                    throw new ArgumentOutOfRangeException("Hours", "Is negative"); 
                }

            }
        }
    }
}
