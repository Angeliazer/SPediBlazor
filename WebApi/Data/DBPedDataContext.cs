using LibraryShared.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class DBPedDataContext(DbContextOptions<DBPedDataContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<Endereco> Enderecos { get; set; } = default!;
        public DbSet<Produto> Produtos { get; set; } = default!;
        public DbSet<Categoria> Categorias { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;
        public DbSet<ItPedido> ItPedidos { get; set; } = default!;
    }
}