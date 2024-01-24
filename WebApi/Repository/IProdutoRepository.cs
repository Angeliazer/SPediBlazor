using LibraryShared.Models;

namespace WebApi.Repository
{
    public interface IProdutoRepository
    {
        Task<Produto> GetProduto(int id);

        Task<RetGetProdutos> GetProdutos(int pag, int size);

        Task<Produto> AddProduto(Produto produto);

        Task<Produto?> UpdateProduto(Produto produto);

        Task<Produto?> RemoveProduto(int id);

        Task<RetGetProdutos>? GetProdutosNome(string nome, int PagNumber, int PageSize);
    }
}
