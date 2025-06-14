using System.ComponentModel.DataAnnotations;

namespace AT_DWNBD.Models
{
    public class PaisDestino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do país é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do país deve ter entre 3 e 100 caracteres.")]
        [Display(Name = "Nome do País")]
        public string Nome { get; set; } = string.Empty;

        public ICollection<CidadeDestino> Cidades { get; set; } = new List<CidadeDestino>();
    }
}