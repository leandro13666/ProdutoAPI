using Microsoft.EntityFrameworkCore;
using ProdutoAPI.Data;
using ProdutoAPI.Models;
using ProdutoAPI.Repositorios.Interfaces;

namespace ProdutoAPI.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ProdutoDBContext _dbContext;
        public ClienteRepositorio(ProdutoDBContext produtoDBContext)
        {
            _dbContext = produtoDBContext;
        }

        public async Task<ClienteModel> BuscarPorID(int id)
        {
            return await _dbContext.Cliente.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ClienteModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Cliente.ToListAsync();
        }
        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {
            await _dbContext.Cliente.AddAsync(cliente);
           await _dbContext.SaveChangesAsync();

            return cliente;

        }
        public async Task<ClienteModel> Atualizar(ClienteModel cliente, int id)
        {
            ClienteModel clientePorId = await BuscarPorID(id);

            if (clientePorId == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontrado.");
            }

            clientePorId.Nome = cliente.Nome;
            clientePorId.Email = cliente.Email;
            clientePorId.Endereco = cliente.Endereco;

            _dbContext.Cliente.Update(clientePorId);
           await _dbContext.SaveChangesAsync();

            return clientePorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ClienteModel clientePorId = await BuscarPorID(id);

            if (clientePorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado.");
            }

            _dbContext.Cliente.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<List<ClienteModel>> BuscarTodosClientes()
        {
            throw new NotImplementedException();
        }
    }
}
