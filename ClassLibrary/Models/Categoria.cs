using System.ComponentModel.DataAnnotations;

namespace LibraryShared.Models
{
    public class Categoria
    {
        [Key] public int IdCategoria { get; set; }

        [Required]
        [MaxLength(50)]
        public string? NomeCategoria { get; set; }
    }
}
