using LibraryShared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository? _repository;

        public CategoriasController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("nomecategoria/")]
        public async Task<ActionResult<Categoria>> PesquisaNome(string nome)
        {
            var categoria = await _repository.PesquisaNome(nome);

            if (categoria == null)
            {
                return NotFound(new Categoria());
            }
            return Ok(categoria);
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetCategorias()
        {
            try
            {
                var categorias = await _repository.GetCategorias();

                if (categorias?.Count != 0)
                {
                    return Ok(categorias);
                }
                return NotFound("Banco de dados Vazio....!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Categoria>> RemoveCategoria(int id)
        {
            try
            {
                var categoria = await _repository.RemoveCategoria(id);

                if (categoria == null)
                {
                    return NotFound($"Categoria com o Id = {id} não foi Encontrado....!");
                }
                return Ok(categoria);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>?> AddCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _repository.AddCategoria(categoria);
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
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            try
            {
                var categoria = await _repository.GetCategoria(id);

                if (categoria == null)
                {
                    return NotFound($"Categoria com o Id = {id} não foi Encontrado....!");
                }
                return Ok(categoria);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpGet("pesqcategorias/{id:int}")]
        public async Task<ActionResult<Categoria>> PesqCategorias(int id)
        {
            var categoria = await _repository.PesqCategorias(id);

            if (categoria == null) 
                return NotFound(new Categoria());
            
            return Ok(categoria);
        }
    }
}
