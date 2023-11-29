using LibraryShared.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClientesController(IClienteRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        public async Task<ActionResult<Cliente>?> AddCliente(Cliente cliente)
        {
            try
            {
                var result = await _repository.AddCliente(cliente);
                if (result != null)
                {
                    return Ok(result);
                }
                Console.WriteLine("Teste");
                return null;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            try
            {
                var cliente = await _repository.GetCliente(id);

                if (cliente == null)
                {
                    return NotFound($"Cliente com o Id = {id} não foi Encontrado....!");
                }
                return Ok(cliente);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetClientes()
        {
            try
            {
                var clientes = await _repository.GetClientes();

                if (clientes?.Count != 0)
                {
                    return Ok(clientes);
                }
                return NotFound("Banco de dados Vazio....!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados...!");
            }
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<List<Cliente>>> GetClientesNome(string nome)
        {
            try
            {
                var clientes = await _repository.GetClientesNome(nome);

                if (clientes?.Count != 0)
                {
                    return Ok(clientes);
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
