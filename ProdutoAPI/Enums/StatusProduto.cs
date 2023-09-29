using System.ComponentModel;

namespace ProdutoAPI.Enums
{
    public enum StatusProduto
    {
        [Description("Em processo")]
        EmProcesso = 1,
        [Description("Compra efetuada")]
        CompraEfetuada = 2,
        [Description("Conluido")]
        Concluido = 3,
    }
}
