using WebShopAPI.Domain.Models.Pedidos;
using WebShopAPI.Domain.Validations;

namespace WebShopAPI.Domain.Entities.Pedidos;

public partial class Pedido
{
    public void AdicionarProduto(PedidoProdutoAdicionarModel model)
    {
        Guard.Enforce(PedidoIsAtivo(DataFechamento));
        Guard.Enforce(PodeAdicionarProduto(model.Produto, model.Quantidade));

        var pedidoProduto = _pedidoProdutos.FirstOrDefault(p => p.ProdutoId == model.Produto.Id);
        
        if(pedidoProduto == null)
        {
            var pedidoProdutoAdicionar = new PedidoProduto
            {
                Pedido = this,
                Produto = model.Produto,
                QuantidadeProduto = model.Quantidade,
            };

            _pedidoProdutos.Add(pedidoProdutoAdicionar);
        }
        else
        {
            pedidoProduto.Produto.DiminuirQuantidade(model.Quantidade);
            pedidoProduto.QuantidadeProduto += model.Quantidade;
        }
    }

    public void RemoverProduto(long produtoId)
    {
        var pedidoProduto = _pedidoProdutos.FirstOrDefault(p => p.Id == produtoId);

        Guard.Enforce(PodeRemoverProduto(pedidoProduto, DataFechamento));

        pedidoProduto.Produto.AumentarQuantidade(pedidoProduto.QuantidadeProduto);
        pedidoProduto.QuantidadeProduto = 0;

        _pedidoProdutos.Remove(pedidoProduto);
    }

    public void AlterarQuantidadeProduto(long produtoId, long quantidadeNova)
    {
        Guard.Enforce(PodeAlterarQuantidadeProduto(quantidadeNova));

        if (quantidadeNova == 0)
        {
            RemoverProduto(produtoId);
        }
        else
        {
            var pedidoProduto = _pedidoProdutos.First(p => p.Id == produtoId);

            pedidoProduto.Produto.AumentarQuantidade(pedidoProduto.QuantidadeProduto);

            pedidoProduto.Produto.DiminuirQuantidade(quantidadeNova);
            pedidoProduto.QuantidadeProduto = quantidadeNova;
        }
    }

    public void FecharPedido()
    {
        Guard.Enforce(PodeFecharPedido(_pedidoProdutos, DataFechamento));

        DataFechamento = DateTime.Now;
    }
}