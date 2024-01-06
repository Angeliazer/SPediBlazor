using System.ComponentModel.DataAnnotations;

namespace LibraryShared.Models
{
    public class Tliente
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public Ender Ender { get; set; } = new();
    }


}
