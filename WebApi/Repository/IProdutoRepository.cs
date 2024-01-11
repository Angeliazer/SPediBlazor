using LibraryShared.Models;

namespace WebApi.Repository
{
    public interface IProdutoRepository
    {
        Task<Produto?> GetProduto(int id);

        Task<List<Produto>?> GetProdutos();

        Task<Produto?> AddProduto(Produto produto);

        Task<Produto?> UpdateProduto(Produto produto);

        Task<Produto?> RemoveProduto(int id);

        Task<List<Produto>?> GetProdutosNome(string nome);
    }
}
