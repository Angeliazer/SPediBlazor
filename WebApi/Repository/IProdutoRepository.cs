using LibraryShared.Models;

namespace WebApi.Repository
{
    public interface IProdutoRepository
    {
        Task<List<Produto>?> GetProdutos();

        Task<Produto?> GetProduto(int id);

        Task<Produto?> AddProduto(Produto produto);

        Task<List<Produto>?> GetProdutosNome(string nome);

        Task<Produto?> RemoveProduto(int id);
    }
}
