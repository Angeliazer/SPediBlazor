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

        public async Task<Categoria>? AddCategoria(Categoria categoria)
        {
            if (categoria != null)
            {
                using var trans = _context.Database.BeginTransaction();
                try
                {
                    var result = await _context.Categorias.AddAsync(categoria);
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

        public async Task<Categoria>? GetCategoria(int id)
        {
            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(x => x.IdCategoria == id);
            if (categoria != null)
            {
                return categoria;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Categoria>?> GetCategorias()
        {
            var categorias = await _context.Categorias
                .OrderBy(x => x.NomeCategoria)
                .AsNoTracking()
                .ToListAsync();

            if (categorias != null)
            {
                return categorias;
            }
            else
            {
                return null;
            }
        }

        public async Task<Categoria> PesqCategorias(int id)
        {
            var produto = await _context.Produtos
                .FirstOrDefaultAsync(x => x.IdCategoria == id);

            if (produto != null)
            {
                var categ = await _context.Categorias
                    .FirstOrDefaultAsync(x => x.IdCategoria == produto.IdCategoria);

                return categ;
            }
            return new Categoria();
        }

        public async Task<Categoria>? PesquisaNome(string nome)
        {
            var categoria = await _context.Categorias
                .Where(e => e.NomeCategoria == nome)
                .FirstOrDefaultAsync();

            if (categoria != null)
                return categoria;

            return new Categoria();
        }

        public async Task<Categoria>? RemoveCategoria(int id)
        {
            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(x => x.IdCategoria == id);

            if (categoria?.IdCategoria != id)
            {
                return new Categoria();
            }
            else
            {
                var result = _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }
        }
    }
}