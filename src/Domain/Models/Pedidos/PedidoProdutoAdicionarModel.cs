using WebShopAPI.Domain.Entities.Produtos;

namespace WebShopAPI.Domain.Models.Pedidos;

public class PedidoProdutoAdicionarModel
{
    public Produto Produto { get; set; }

    public long Quantidade { get; set; }
}