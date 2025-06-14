using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT_DWNBD.Models; 
using System.Collections.Generic; 

namespace AT_DWNBD.Pages.Cidades
{
    public class CriarCidadeModel : PageModel
    {
        [BindProperty] 
        public CidadeDestino Cidade { get; set; } = new CidadeDestino(); 

        private static List<CidadeDestino> _cidadesCadastradas = new List<CidadeDestino>();
        private static int _nextId = 1; 

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Cidade.Id = _nextId++; 
            _cidadesCadastradas.Add(Cidade); 

            TempData["SuccessMessage"] = $"Cidade '{Cidade.Nome}' cadastrada com sucesso! (ID: {Cidade.Id})";

            return RedirectToPage();
        }

        public static List<CidadeDestino> GetCidadesCadastradas()
        {
            return _cidadesCadastradas;
        }
    }
}