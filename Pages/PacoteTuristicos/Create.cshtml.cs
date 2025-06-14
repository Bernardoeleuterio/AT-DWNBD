using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AT_DWNBD.Data;
using AT_DWNBD.Models;
using Microsoft.AspNetCore.Authorization;

namespace AT_DWNBD.Pages.PacoteTuristicos
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly AT_DWNBDContext _context;

        public CreateModel(AT_DWNBDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PacoteTuristico.Add(PacoteTuristico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
