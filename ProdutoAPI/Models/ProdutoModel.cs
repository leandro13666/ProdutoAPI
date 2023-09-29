using ProdutoAPI.Enums;

namespace ProdutoAPI.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Descricao { get; set; }

        public int Preco { get; set; }

        public StatusProduto Status { get; set; }   


    }
}
