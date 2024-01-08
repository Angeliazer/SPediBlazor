using LibraryShared.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DBPedDataContext _context;

        public CategoriaRepository(DBPedDataContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>?>GetCategorias()
        {
            var categorias = await _context.Categorias
                .AsNoTracking()
                .ToListAsync();

            if (categorias.Count == 0) return null;

            return categorias;
        }
    }
}
