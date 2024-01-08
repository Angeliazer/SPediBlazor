using LibraryShared.Models;

namespace WebApi.Repository
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>?> GetCategorias();
    }
}
