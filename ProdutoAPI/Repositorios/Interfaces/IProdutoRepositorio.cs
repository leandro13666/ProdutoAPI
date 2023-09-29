using ProdutoAPI.Models;

namespace ProdutoAPI.Repositorios.Interfaces
{
   public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodosProdutos();
        Task<ProdutoModel> BuscarPorID (int id);
        Task<ProdutoModel> Adicionar(ProdutoModel produto);
        Task<ProdutoModel> Atualizar(ProdutoModel produto, int id  );

        Task<bool> Apagar (int id );
    }
}
