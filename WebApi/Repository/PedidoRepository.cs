using LibraryShared.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repository
{
    public class PedidoRepository(DBPedDataContext context) : IPedidoRepository
    {

        private readonly DBPedDataContext _context = context;

        public async Task<Pedido?> AddPedido(Pedido pedido)
        {
            if (pedido != null)
            {
                using var trans = _context.Database.BeginTransaction();
                try
                {
                    var result = await _context.Pedidos.AddAsync(pedido);
                    await _context.SaveChangesAsync();

                    trans.Commit();

                    return result.Entity;
                }
                catch
                {
                    trans.Rollback();
                }
            }
            return new Pedido();
        }


        public async Task<List<Pedido>?> GetAllCliente(int idCliente)
        {
            var pedidos = await _context.Pedidos
                .Where(y => y.IdCliente == idCliente)
                .OrderByDescending(x => x.DataCadastro)
                .AsNoTracking()
                .ToListAsync();

            if (pedidos != null)
            {
                return pedidos;
            }
            else
            {
                return [];
            }
        }
    }
}
