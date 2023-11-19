using ProdutoAPI.Models;

namespace ProdutoAPI.Repositorios.Interfaces
{
   public interface IClienteRepositorio
    {
        Task<List<ClienteModel>> BuscarTodosClientes();
        Task<ClienteModel> BuscarPorID (int id);
        Task<ClienteModel> Adicionar(ClienteModel cliente);
        Task<ClienteModel> Atualizar(ClienteModel cliente, int id  );

        Task<bool> Apagar (int id );
    }
}
