using LibraryShared.Models;

namespace WebApi.Repository
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>?> GetCategorias();

        Task<Categoria>? GetCategoria(int id);

        Task<Categoria>? AddCategoria(Categoria categoria);

        Task<Categoria>? PesquisaNome(string nome);

        Task<Categoria>? RemoveCategoria(int id);

        Task<Categoria>? PesqCategorias(int id);
    }
}
