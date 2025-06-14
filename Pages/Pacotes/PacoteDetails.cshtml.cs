using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT_DWNBD.Models; 
using AT_DWNBD.Pages.Pacotes;
using System.Linq; 

namespace AT_DWNBD.Pages.Pacotes
{
    public class PacoteDetailsModel : PageModel
    {
        public PacoteTuristico Pacote { get; set; } = default!; 

        public IActionResult OnGet(int id)
        {
            var pacotes = CriarPacoteModel.GetPacotesCadastradas(); 

            Pacote = pacotes.FirstOrDefault(p => p.Id == id);

            if (Pacote == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}