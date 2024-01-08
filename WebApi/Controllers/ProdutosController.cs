using LibraryShared.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProdutos()
        {
            try
            {
                var produtos = await _repository.GetProdutos();

                if (produtos?.Count != 0)
                {
                    return Ok(produtos);
                }
                return Ok("Banco de dados Vazio....!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<List<Produto>>> GetProdutosNome(string nome)
        {
            try
            {
                var produtos = await _repository.GetProdutosNome(nome);

                if (produtos?.Count != 0)
                {
                    return Ok(produtos);
                }
                return NotFound("Banco de dados Vazio....!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }
    }
}

