using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryShared.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public DateTime DataCadastro { get; set; } = Convert.ToDateTime($"{DateTime.Now:dd/MM/yyy}");
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPedido { get; set; }
        
        public int IdCliente { get; set; }

        public List<ItPedido> ListaItPedidos { get; set; } = [];
    }
}
