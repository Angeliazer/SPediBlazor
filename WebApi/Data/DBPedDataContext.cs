using ApiPedido.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class DBPedDataContext(DbContextOptions<DBPedDataContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; } = default!;
    }
}