using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; 
using AT_DWNBD.Data;
using AT_DWNBD.Models;
using Microsoft.AspNetCore.Authorization;

namespace AT_DWNBD.Pages.PacoteTuristicos
{
    [Authorize] 
    public class DeleteModel : PageModel
    {
        private readonly AT_DWNBDContext _context;

        public DeleteModel(AT_DWNBDContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturistico = await _context.PacoteTuristico.FirstOrDefaultAsync(m => m.Id == id);

            if (pacoteturistico == null)
            {
                return NotFound();
            }
            else
            {
                PacoteTuristico = pacoteturistico;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturistico = await _context.PacoteTuristico.FindAsync(id);

            if (pacoteturistico != null)
            {
                pacoteturistico.IsDeleted = true;


                await _context.SaveChangesAsync(); 
            }

            return RedirectToPage("./Index"); 
        }
    }
}