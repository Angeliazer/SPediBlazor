using LibraryShared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Data;

namespace WebApi.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DBPedDataContext _context;

        public ProdutoRepository(DBPedDataContext context)
        {
            _context = context;
        }

        public async Task<Produto> AddProduto(Produto produto)
        {
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
            return null!;
        }

        public async Task<Produto> GetProduto(int id)
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

        public async Task<RetGetProdutos> GetProdutos(int pageNumber, int pageSize)
        {
            var nroReg = await _context.Produtos.CountAsync();

            RetGetProdutos retorno = new();

            var produtos = await _context.Produtos
                           .OrderBy(x => x.NomeProduto)
                           .Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .ToListAsync();

            retorno.ListaProdutos = produtos;
            retorno.TotalReg = nroReg;

            if (produtos.Count != 0)
            {
                return retorno;
            }
            else
            {
                return (retorno = new());
            }
        }

        public async Task<RetGetProdutos>? GetProdutosNome(string nome, int PageNumber, int PageSize)
        {
            var nroReg = await _context.Produtos.CountAsync();

            RetGetProdutos retorno = new();

            var produtos = await _context.Produtos
              .Where(x => string.IsNullOrEmpty(nome) || EF.Functions.Like (x.NomeProduto, nome + "%") )
              .OrderBy(x => x.NomeProduto)
              .AsNoTracking()
              .Skip((PageNumber - 1) * PageSize)
              .Take(PageSize)
              .ToListAsync();

            retorno.ListaProdutos = produtos;
            retorno.TotalReg = produtos.Count();

            if (produtos.Count != 0)
            {
                return retorno;
            }
            else
            {
                return (retorno = new());
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
