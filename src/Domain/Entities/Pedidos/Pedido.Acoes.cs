using WebShopAPI.Domain.Entities.Produtos;

namespace WebShopAPI.Domain.Entities.Pedidos;

public partial class Pedido
{
    public void AdicionarProdutos(List<(Produto, long)> produtos)
    {
        foreach (var produto in produtos) {
            var pedidoProduto = new PedidoProduto
            {
                Pedido = this,
                Produto = produto.Item1,
                QuantidadeProduto = produto.Item2,
            };

            _produtos.Add(pedidoProduto);
        }
    }

    public void RemoverProduto(long produtoId)
    {
        var produto = _produtos.First(p => p.Id == produtoId);
        _produtos.Remove(produto);
    }

    public void FecharPedido()
    {
        // TODO Validacao para fechamento

        DataFechamento = DateTime.Now;
    }

    //public void CancelarPedido()
    //{
    //  IsAtivo = false? DataAbertura = 0? Excluir registro?
    //}
}