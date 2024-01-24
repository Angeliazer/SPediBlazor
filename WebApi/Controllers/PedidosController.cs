using LibraryShared.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _repository;

        public PedidosController(IPedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>?> AddCliente(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _repository.AddPedido(pedido);
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

        [HttpGet("{idCliente:int}")]
        public async Task<ActionResult<List<Pedido>>> GetAllCliente(int idCliente)
        {
            try
            {
                var pedidos = await _repository.GetAllCliente(idCliente);

                if (pedidos?.Count != 0)
                {
                    return Ok(pedidos);
                }
                return Ok(new List<Pedido>());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }
    }
}
