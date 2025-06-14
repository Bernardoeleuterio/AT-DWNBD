using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT_DWNBD.Models;
using System.Collections.Generic;
using System.Linq; 

namespace AT_DWNBD.Pages.Pacotes
{
    public class CriarPacoteModel : PageModel
    {
        [BindProperty]
        public PacoteTuristico Pacote { get; set; } = new PacoteTuristico(); 

        private static List<PacoteTuristico> _pacotesCadastrados = new List<PacoteTuristico>();
        private static int _nextId = 1;

        public void OnGet()
        {
            Pacote.DataInicio = DateTime.Now.AddDays(1);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            Pacote.Id = _nextId++;
            _pacotesCadastrados.Add(Pacote);

            TempData["SuccessMessage"] = $"Pacote '{Pacote.Titulo}' cadastrado com sucesso! (ID: {Pacote.Id})";

            return RedirectToPage();
        }

        public static List<PacoteTuristico> GetPacotesCadastradas()
        {
            return _pacotesCadastrados;
        }
    }
}