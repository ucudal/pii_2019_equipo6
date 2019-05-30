using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostRegister(string RegisterButton)
        {
            return RedirectToPage("Register");
        }
        public IActionResult OnPostLogin(string LoginButton)
        {
            return RedirectToPage("Login");
        }
    }
}
