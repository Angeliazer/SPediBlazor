using LibraryShared.Models;

namespace WebApi.Repository
{
    public interface IPedidoRepository
    {
        Task<Pedido?> AddPedido(Pedido pedido);

        Task<List<Pedido>?> GetAllCliente(int idCliente);
    }
}
