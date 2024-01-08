using System.ComponentModel.DataAnnotations;

namespace LibraryShared.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        [Required]
        public string? NomeCategoria { get; }
    }
}
