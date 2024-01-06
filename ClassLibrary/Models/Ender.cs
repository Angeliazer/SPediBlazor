using System.ComponentModel.DataAnnotations;

namespace LibraryShared.Models
{
    public class Ender
    {
        [Required]
        public string Rua { get; set; }

        [Required]
        public string Cidade { get; set; }
        // Outras propriedades do Endereco
    }
}
