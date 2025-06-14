using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace AT_DWNBD.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título do pacote é obrigatório.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "O título deve ter entre 5 e 150 caracteres.")]
        [Display(Name = "Título do Pacote")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Início")]
        [FutureDate(ErrorMessage = "A data de início deve ser uma data futura.")]
        public DateTime DataInicio { get; set; } = DateTime.Now.AddDays(1);

        [Required(ErrorMessage = "A capacidade máxima é obrigatória.")]
        [Range(1, 1000, ErrorMessage = "A capacidade máxima deve ser entre 1 e 1000 participantes.")]
        [Display(Name = "Capacidade Máxima")]
        public int CapacidadeMaxima { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 100000.00, ErrorMessage = "O preço deve ser maior que zero e não exceder 100.000.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        public bool IsDeleted { get; set; } = false; 

        public PacoteTuristico(int id, string titulo, int capacidadeMaxima)
        {
            Id = id;
            Titulo = titulo;
            CapacidadeMaxima = capacidadeMaxima;
            ReservasRealizadas = 0;
        }

        public PacoteTuristico()
        {
        }

        public delegate void CapacityReachedEventHandler(string packageName, int currentParticipants, int maxCapacity);
        public event CapacityReachedEventHandler? CapacityReached;
        public int ReservasRealizadas { get; private set; }

        public bool AdicionarParticipante()
        {
            if (ReservasRealizadas < CapacidadeMaxima)
            {
                ReservasRealizadas++;
                if (ReservasRealizadas == CapacidadeMaxima)
                {
                    OnCapacityReached();
                }
                return true;
            }
            else
            {
                OnCapacityReached();
                return false;
            }
        }

        protected virtual void OnCapacityReached()
        {
            CapacityReached?.Invoke(Titulo, ReservasRealizadas, CapacidadeMaxima);
        }

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

        public ICollection<CidadeDestino> CidadesDestino { get; set; } = new List<CidadeDestino>();
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.Date > DateTime.Now.Date;
            }
            return false;
        }
    }
}