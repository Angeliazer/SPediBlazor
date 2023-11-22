using ApiPedido.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using WebApi.Data;

namespace WebApi.Repository
{
    public class ClienteRepository(DBPedDataContext context) : IClienteRepository
    {
        private readonly DBPedDataContext _context = context;

        public async Task<Cliente?> AddCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                var result = await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<Cliente?> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.ClienteId == id);
            if (cliente != null)
            {
                return cliente;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Cliente>?> GetClientes()
        {
            var clientes = await _context.Clientes
             .OrderBy(x => x.NomeCliente)
             .AsNoTracking()
             .ToListAsync();

            if (clientes != null)
            {
                return clientes;
            }
            else
            {
                return null;
            }
        }
    }
}
