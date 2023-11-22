using ApiPedido.Models;

namespace WebApi.Repository
{
    public interface IClienteRepository
    {
        Task<List<Cliente>?> GetClientes();

        Task<Cliente?> GetCliente(int id);

        Task<Cliente?> AddCliente(Cliente cliente);
    }
}
