using LibraryShared.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public ProdutosController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>?> AddProduto(Produto produto)
        {
            try
            {
                var result = await _repository.AddProduto(produto);
                if (result != null)
                {
                    return Ok(result);
                }
                return null;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            try
            {
                var produto = await _repository.GetProduto(id);

                if (produto == null)
                {
                    return NotFound($"Produto com o Id = {id} não foi Encontrado....!");
                }
                return Ok(produto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Produto>> Removeproduto(int id)
        {
            try
            {
                var produto = await _repository.RemoveProduto(id);

                if (produto == null)
                {
                    return NotFound($"Produto com o Id = {id} não foi Encontrado....!");
                }
                return Ok(produto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpGet("{page:int}/{size:int}")]
        public async Task<ActionResult<RetGetProdutos>> GetProdutos(int page, int size)
        {
            try
            {
                var retorno = await _repository.GetProdutos(page, size);

                if (retorno.ListaProdutos.Count != 0)
                {

                    return Ok(retorno);
                }
                else
                {
                    return BadRequest(retorno=new());
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpGet("getprodutosnome/")]
        public async Task<ActionResult<RetGetProdutos>?> GetProdutosNome(string nome, int PageNumber, int PageSize)
        {
            try
            {
                var retorno = await _repository.GetProdutosNome(nome, PageNumber, PageSize);

                if (retorno.ListaProdutos?.Count != 0)
                {
                    return Ok(retorno);
                }
                return NotFound("Banco de dados Vazio....!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Produto>> UpdateCliente(Produto produto)
        {
            try
            {
                var pro_ban = await _repository.UpdateProduto(produto);

                if (pro_ban == null)
                {
                    return NotFound($"Cliente com o Id = {produto.IdProduto} não foi Encontrado....!");
                }
                return Ok(produto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }
    }
}

