using WebShopAPI.Domain.Entities.Produtos;

namespace WebShopAPI.Domain.Entities.Pedidos;

public class PedidoProduto : BaseEntity<long>
{
    public long QuantidadeProduto { get; set; }

    public long PedidoId { get; set; }

    public Pedido Pedido { get; set; }

    public long ProdutoId { get; set; }

    public Produto Produto { get; set; }
}