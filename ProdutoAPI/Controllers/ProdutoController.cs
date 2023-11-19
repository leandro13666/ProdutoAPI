using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutoAPI.Models;
using ProdutoAPI.Repositorios.Interfaces;

namespace ProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarPorId(int id)
        {
            ProdutoModel produtos = await _produtoRepositorio.BuscarPorID(id);
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody] ProdutoModel produto)
        {
           ProdutoModel produtos = await _produtoRepositorio.Adicionar(produto);
           return Ok(produto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar ([FromBody] ProdutoModel produtoModel, int id)
        {
            produtoModel.Id = id;
            ProdutoModel produtos = await _produtoRepositorio.Atualizar(produtoModel, id);
            return Ok(produtos);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> Apagar(int id)
        {
            bool apagado = await _produtoRepositorio.Apagar(id);    
            return Ok(apagado);
        }
       

    }

}
