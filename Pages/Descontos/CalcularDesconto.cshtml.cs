using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT_DWNBD.Delegates; 

namespace AT_DWNBD.Pages.Descontos
{
    public class CalcularDescontoModel : PageModel
    {
        [BindProperty] 
        public decimal PrecoOriginal { get; set; }

        public decimal PrecoComDesconto { get; set; }

        private DiscountCalculator _discountCalculator = DiscountOperations.ApplyTenPercentDiscount;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (PrecoOriginal <= 0)
            {
                ModelState.AddModelError("PrecoOriginal", "O preço deve ser um valor positivo.");
                return;
            }

            PrecoComDesconto = _discountCalculator(PrecoOriginal);
        }
    }
}