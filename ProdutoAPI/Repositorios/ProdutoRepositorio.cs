using Microsoft.EntityFrameworkCore;
using ProdutoAPI.Data;
using ProdutoAPI.Models;
using ProdutoAPI.Repositorios.Interfaces;

namespace ProdutoAPI.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ProdutoDBContext _dbContext;
        public ProdutoRepositorio(ProdutoDBContext produtoDBContext)
        {
            _dbContext = produtoDBContext;
        }

        public async Task<ProdutoModel> BuscarPorID(int id)
        {
            return await _dbContext.Produto.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produto.ToListAsync();
        }
        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbContext.Produto.AddAsync(produto);
           await _dbContext.SaveChangesAsync();

            return produto;

        }
        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            ProdutoModel produtoPorId = await BuscarPorID(id);

            if (produtoPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado.");
            }

            produtoPorId.Name = produto.Name;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.Preco = produto.Preco;

            _dbContext.Produto.Update(produtoPorId);
           await _dbContext.SaveChangesAsync();

            return produtoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutoModel produtoPorId = await BuscarPorID(id);

            if (produtoPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado.");
            }

            _dbContext.Produto.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
