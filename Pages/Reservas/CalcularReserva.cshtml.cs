using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System; 

namespace AT_DWNBD.Pages.Reservas
{
    public class CalcularReservaModel : PageModel
    {
        [BindProperty]
        public int NumeroDiarias { get; set; }

        [BindProperty]
        public decimal ValorDiaria { get; set; }

        public decimal ValorTotalReserva { get; set; }

        private Func<int, decimal, decimal> _calcularValorTotal;

        public CalcularReservaModel()
        {
            _calcularValorTotal = (numDiarias, valDiaria) => numDiarias * valDiaria;
        }

        public void OnGet()
        {
            ValorTotalReserva = 0;
            NumeroDiarias = 0;
            ValorDiaria = 0;
        }

        public void OnPost()
        {
            if (NumeroDiarias <= 0)
            {
                ModelState.AddModelError("NumeroDiarias", "O número de diárias deve ser maior que zero.");
            }
            if (ValorDiaria <= 0)
            {
                ModelState.AddModelError("ValorDiaria", "O valor da diária deve ser maior que zero.");
            }

            if (!ModelState.IsValid)
            {
                ValorTotalReserva = 0;
                return;
            }

            ValorTotalReserva = _calcularValorTotal(NumeroDiarias, ValorDiaria);
        }
    }
}