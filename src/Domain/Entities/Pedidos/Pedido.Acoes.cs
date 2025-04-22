using WebShopAPI.Domain.Models.Pedidos;
using WebShopAPI.Domain.Validations;

namespace WebShopAPI.Domain.Entities.Pedidos;

public partial class Pedido
{
    public void AdicionarProduto(PedidoProdutoAdicionarModel model)
    {
        var pedidoProduto = new PedidoProduto
        {
            Pedido = this,
            Produto = model.Produto,
            QuantidadeProduto = model.Quantidade,
        };

        _produtos.Add(pedidoProduto);
    }

    public void RemoverProduto(long produtoId)
    {
        var produto = _produtos.First(p => p.Id == produtoId);

        produto.QuantidadeProduto = 0;

        _produtos.Remove(produto);
    }

    public void AlterarQuantidadeProduto(long produtoId, long quantidadeNova)
    {
        if (quantidadeNova == 0)
        {
            RemoverProduto(produtoId);
        }
        else
        {
            var produto = _produtos.First(p => p.Id == produtoId);

            produto.QuantidadeProduto = quantidadeNova;
        }
    }

    public void FecharPedido()
    {
        Guard.Enforce(PodeFecharPedido(_produtos));

        DataFechamento = DateTime.Now;
    }
}