using LibraryShared.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
                using var trans = _context.Database.BeginTransaction();
                try
                {
                    var result = await _context.Clientes.AddAsync(cliente);
                    await _context.SaveChangesAsync();

                    trans.Commit();

                    return result.Entity;
                }
                catch
                {
                    trans.Rollback();
                }
            }
            return null;
        }

        public async Task<Cliente?> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                .Include("Endereco")
                .FirstOrDefaultAsync(x => x.ClienteId == id);

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
             .Include(p => p.Endereco)
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
            if (cliente?.ClienteId != id)
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

        public async Task<Cliente?> UpdateCliente(Cliente cliente)
        {
            var cliente_banco = await _context.Clientes
                .Include("Endereco")
                .FirstOrDefaultAsync(x => x.ClienteId == cliente.ClienteId);
           
            if (cliente_banco?.ClienteId != cliente.ClienteId)
            {
                return new Cliente();
            }
            else
            {
                cliente_banco.CpfCliente = cliente.CpfCliente;
                cliente_banco.CnpjCliente = cliente.CnpjCliente;
                cliente_banco.NomeCliente = cliente.NomeCliente;
                cliente_banco.NomeContato = cliente.NomeContato;
                cliente_banco.TipoCliente = cliente.TipoCliente;
                cliente_banco.Email = cliente.Email;
                cliente_banco.LimiteCredito = cliente.LimiteCredito;
                cliente_banco.NroTelefone = cliente.NroTelefone;
                cliente_banco.DataCadastro = cliente.DataCadastro;

                cliente_banco.Endereco.NomeRua = cliente.Endereco.NomeRua;
                cliente_banco.Endereco.Numero = cliente.Endereco.Numero;
                cliente_banco.Endereco.Bairro = cliente.Endereco.Bairro;
                cliente_banco.Endereco.Cidade = cliente.Endereco.Cidade;
                cliente_banco.Endereco.Estado = cliente.Endereco.Estado;
                cliente_banco.Endereco.Cep = cliente.Endereco.Cep;
                await _context.SaveChangesAsync();
                return cliente;
            }
        }
    }
}

