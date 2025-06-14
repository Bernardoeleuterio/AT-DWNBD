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
    public class IndexModel : PageModel
    {
        private readonly AT_DWNBDContext _context;

        public IndexModel(AT_DWNBDContext context)
        {
            _context = context;
        }

        public IList<PacoteTuristico> PacoteTuristico { get; set; } = default!;

        public async Task OnGetAsync()
        {
            PacoteTuristico = await _context.PacoteTuristico
                                    .Where(p => !p.IsDeleted)
                                    .ToListAsync();
        }
    }
}