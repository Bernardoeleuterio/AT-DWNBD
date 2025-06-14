using System.ComponentModel.DataAnnotations;

namespace AT_DWNBD.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 150 caracteres.")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(200, ErrorMessage = "O e-mail não pode exceder 200 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "O telefone não pode exceder 20 caracteres.")]
        [Phone(ErrorMessage = "Formato de telefone inválido.")]
        public string? Telefone { get; set; } 

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}