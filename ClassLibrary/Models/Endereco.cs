using LibraryShared.Models.Enumeradores;
using System.ComponentModel.DataAnnotations;

namespace LibraryShared.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "Nome da Rua")]
        public string? NomeRua { get; set; }

        [MaxLength(15)]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "Número")]
        public string? Numero { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "Bairro")]
        public string? Bairro { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "Cidade")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "Estado")]
        public EEstado Estado { get; set; }

        [MaxLength(8)]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "Cep")]
        public string? Cep { get; set; }

        public int ClienteId { get; set; }
    }
}
