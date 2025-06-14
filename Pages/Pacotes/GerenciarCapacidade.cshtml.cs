using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT_DWNBD.Models; 
using AT_DWNBD.Services; 

namespace AT_DWNBD.Pages.Pacotes
{
    public class GerenciarCapacidadeModel : PageModel
    {
        private static PacoteTuristico _pacoteTuristico = new PacoteTuristico(1, "Cruzerio do Neymar", 3); 

        public string PacoteTitulo => _pacoteTuristico.Titulo;
        public int CapacidadeMaxima => _pacoteTuristico.CapacidadeMaxima;
        public int ReservasAtuais => _pacoteTuristico.ReservasRealizadas;
        public string MensagemStatus { get; set; } = string.Empty;

        public GerenciarCapacidadeModel()
        {
            _pacoteTuristico.CapacityReached -= EventLogService.LogCapacityAlert; 
            _pacoteTuristico.CapacityReached += EventLogService.LogCapacityAlert; 
        }

        public void OnGet()
        {
            AtualizarMensagemStatus();
        }

        public IActionResult OnPostAdicionarReserva()
        {
            if (_pacoteTuristico.AdicionarParticipante())
            {
                MensagemStatus = $"Reserva adicionada para '{_pacoteTuristico.Titulo}'.";
            }
            else
            {
                MensagemStatus = $"N�o foi poss�vel adicionar reserva. O pacote '{_pacoteTuristico.Titulo}' atingiu ou excedeu a capacidade m�xima ({_pacoteTuristico.CapacidadeMaxima} participantes).";
            }

            AtualizarMensagemStatus(); 
            return Page(); 
        }

        private void AtualizarMensagemStatus()
        {
            if (_pacoteTuristico.ReservasRealizadas >= _pacoteTuristico.CapacidadeMaxima)
            {
                MensagemStatus = $"ATEN��O: A capacidade m�xima do pacote '{_pacoteTuristico.Titulo}' foi atingida ou excedida ({_pacoteTuristico.ReservasRealizadas}/{_pacoteTuristico.CapacidadeMaxima}).";
            }
            else if (string.IsNullOrEmpty(MensagemStatus)) 
            {
                MensagemStatus = $"Capacidade atual: {_pacoteTuristico.ReservasRealizadas}/{_pacoteTuristico.CapacidadeMaxima}. Ainda h� vagas!";
            }
        }
    }
}