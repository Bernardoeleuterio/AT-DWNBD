using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; 

namespace AT_DWNBD.Models
{
    public class CidadeDestino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da cidade deve ter entre 3 e 100 caracteres.")]
        [Display(Name = "Nome da Cidade")]
        public string Nome { get; set; } = string.Empty;

        public int PaisDestinoId { get; set; }
        public PaisDestino PaisDestino { get; set; } = default!;

        public ICollection<PacoteTuristico> PacotesTuristicos { get; set; } = new List<PacoteTuristico>();
    }
}