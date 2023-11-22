using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiPedido.Models.Enumeradores;

namespace ApiPedido.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        public ETipoEndereco TipoEnd { get; set; }

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
