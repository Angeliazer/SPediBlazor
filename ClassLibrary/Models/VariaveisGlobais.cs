namespace LibraryShared.Models
{
    public class VariaveisGlobais
    {
        public bool IniciaLista { get; set; }
        public decimal TotalPedido { get; set; }
        public List<ItPedido> ListaItensPedidos { get; set; } = [];
        public string? NomeUsuario { get; set; }
    }
}
