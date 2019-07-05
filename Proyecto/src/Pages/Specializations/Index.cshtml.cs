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
            errorcheck();
        }

        private void errorcheck()
        {
            int num=0;
            foreach(var i in Specialization)
            {
                foreach(var x in Specialization)
                {
                    if(x.Name==i.Name)
                    {
                        num+=1;
                        if(num==2)
                        {
                            throw new ArgumentException("Especializacion","Ya existe");
                        }
                    }
                }
                num=0;
            }
        }
    }
}
