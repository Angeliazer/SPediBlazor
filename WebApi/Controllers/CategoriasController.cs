using LibraryShared.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriasController(ICategoriaRepository repository)
        {
            _repository = repository;
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
    }
}
