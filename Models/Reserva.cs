using System.ComponentModel.DataAnnotations;

namespace AT_DWNBD.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Display(Name = "Data da Reserva")]
        public DateTime DataReserva { get; set; } = DateTime.Now;

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = default!;

        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        [Required(ErrorMessage = "O número de participantes é obrigatório.")]
        [Range(1, 10, ErrorMessage = "A reserva deve ser para 1 a 10 participantes.")]
        [Display(Name = "Número de Participantes")]
        public int NumeroParticipantes { get; set; }
    }
}