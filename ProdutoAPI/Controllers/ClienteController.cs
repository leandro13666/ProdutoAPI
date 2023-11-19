using Microsoft.AspNetCore.Mvc;
using ProdutoAPI.Models;
using ProdutoAPI.Repositorios.Interfaces;

namespace ProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> BuscarTodosCLientes()
        {
            List<ClienteModel> clientes = await _clienteRepositorio.BuscarTodosClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ClienteModel>>> BuscarPorId(int id)
        {
            ClienteModel clientes = await _clienteRepositorio.BuscarPorID(id);
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Cadastrar([FromBody] ClienteModel cliente)
        {
            ClienteModel clientes = await _clienteRepositorio.Adicionar(cliente);
            return Ok(cliente);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteModel>> Atualizar([FromBody] ClienteModel clienteModel, int id)
        {
            clienteModel.Id = id;
            ClienteModel clientes = await _clienteRepositorio.Atualizar(clienteModel, id);
            return Ok(clientes);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> Apagar(int id)
        {
            bool apagado = await _clienteRepositorio.Apagar(id);
            return Ok(apagado);
        }


    }

}
