using LibraryShared.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DBPedDataContext _context;

        public ProdutoRepository (DBPedDataContext context)
        {
            _context = context;
        }

        public async Task<Produto?> AddProduto(Produto produto)
        {
            if (produto != null)
            {
                using var trans = _context.Database.BeginTransaction();
                try
                {
                    var result = await _context.Produtos.AddAsync(produto);
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

        public async Task<Produto?> GetProduto(int id)
        {
            var produto = await _context.Produtos
                .FirstOrDefaultAsync(x => x.IdProduto == id);
            if (produto != null)
            {
                return produto;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Produto>?> GetProdutos()
        {
            var produtos = await _context.Produtos
           .OrderBy(x => x.NomeProduto)
           .AsNoTracking()
           .ToListAsync();

            if (produtos != null)
            {
                return produtos;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Produto>?> GetProdutosNome(string nome)
        {
            var produtos = await _context.Produtos
              .Where(x => x.Descricao != null && x.Descricao.Contains(nome))
              .OrderBy(x => x.Descricao)
              //.AsNoTracking()
              .ToListAsync();

            if (produtos != null)
            {
                return produtos;
            }
            else
            {
                return null;
            }
        }

        public async Task<Produto?> RemoveProduto(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.IdProduto == id);
            if (produto?.IdProduto != id)
            {
                return new Produto();
            }
            else
            {
                var result = _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
        }

        public async Task<Produto?> UpdateProduto(Produto produto)
        {
            var pro_banco = await _context.Produtos
                .FirstOrDefaultAsync(x => x.IdProduto == produto.IdProduto);

            if (pro_banco?.IdProduto != produto.IdProduto)
            {
                return new Produto();
            }
            else
            {
                pro_banco.NomeProduto = produto.NomeProduto;
                pro_banco.Descricao = produto.Descricao;
                pro_banco.QuantEstoque = produto.QuantEstoque;
                pro_banco.Und = produto.Und;
                pro_banco.Preco = produto.Preco;
                pro_banco.DataCadastro = produto.DataCadastro;
                pro_banco.IdCategoria = produto.IdCategoria;
                await _context.SaveChangesAsync();
                return produto;
            }
        }
    }
}
