using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryShared.Models
{
    public class ItPedido
    {
        [Key]
        public int IdItPedido { get; set; }
        public string? NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public string? UndMed { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal VlrUndItem { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal VlrTotalItem { get; set; }

        public int PedidoId { get; set; }
    }
}
