namespace WebShopAPI.Application.Pedidos.Commands;

public class PedidoProdutoDTO
{
    public long PedidoId { get; set; }

    public long ProdutoId { get; set; }

    public long Quantidade { get; set; }
}