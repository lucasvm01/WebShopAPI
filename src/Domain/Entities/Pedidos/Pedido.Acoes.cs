using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Models.Produtos;

namespace WebShopAPI.Domain.Entities.Pedidos;

public partial class Pedido
{
    public Produto AdicionarProduto(long produtoId, ProdutoModel produtoModel)
    {
        // TODO Validacao para adicionar
        var produto = new Produto(produtoModel);
        _produtos.Add(produto);

        return produto;
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

    public void ReabrirPedido() {
        // TODO

        DataFechamento = null;
    }
}