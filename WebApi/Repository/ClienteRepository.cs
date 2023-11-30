using LibraryShared.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DBPedDataContext _context;

        public ClienteRepository(DBPedDataContext context)
        {
            _context = context;
        }

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

        public async Task<List<Cliente>?> GetClientesNome(string nome)
        {
            var clientes = await _context.Clientes
                .Where(x => x.NomeCliente != null && x.NomeCliente.Contains(nome))
                .OrderBy(x => x.NomeCliente)
                //.AsNoTracking()
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

        public async Task<Cliente?> RemoveCliente(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.ClienteId == id);
            if (cliente.ClienteId != id)
            {
                return new Cliente();
            }
            else
            {
                var result = _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
        }

    }
}

