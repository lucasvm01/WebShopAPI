using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Validations;

namespace WebShopAPI.Domain.Entities.Pedidos;

public partial class Pedido
{
    private static List<ValidacaoDominio> PodeIniciarPedido(Pessoa pessoa)
    {
        List<ValidacaoDominio> falhas = new();

        if (pessoa == null)
        {
            falhas.Add(new ValidacaoDominio(pessoa.ToString(), "Campo está vazio"));
        }
        if (pessoa.TipoPessoa != TipoPessoa.IsCliente)
        {
            falhas.Add(new ValidacaoDominio(pessoa.ToString(), "O pedido só pode ser feito para um cliente"));
        }

        return falhas;
    }

    private static List<ValidacaoDominio> PodeAdicionarProduto(Produto produtoAdicionar, long quantidade, List<PedidoProduto> produtos)
    {
        List<ValidacaoDominio> falhas = new();

        if (produtoAdicionar == null)
        {
            falhas.Add(new ValidacaoDominio(produtoAdicionar.ToString(), "Campo está vazio"));
        }

        // TODO
        //if (produtos == null && !PodeRetirarQuantidadeProduto(produto.QuantidadeProduto, quantidade))
        //{

        //}
        else
        {
            foreach (var produto in produtos)
            {
                if (produto.Id == produtoAdicionar.Id &&
                    !PodeRetirarQuantidadeProduto(produto.QuantidadeProduto, quantidade))
                {
                    falhas.Add(new ValidacaoDominio(produtoAdicionar.ToString(), "Não há quantidade de produtos o suficiente para adicionar ao pedido"));
                    break;
                }
            }
        }

        return falhas;
    }

    private static bool PodeRetirarQuantidadeProduto(long quantidadeProduto, long quantidadeRetirar)
    {
        return quantidadeProduto - quantidadeRetirar < 0;
    }

    private static List<ValidacaoDominio> PodeRemoverProduto(Produto produtoAdicionar, long quantidade, List<PedidoProduto> produtos)
    {
        List<ValidacaoDominio> falhas = new();

        if (produtoAdicionar == null)
        {
            falhas.Add(new ValidacaoDominio(produtoAdicionar.ToString(), "Campo está vazio"));
        }

        foreach (var produto in produtos)
        {
            if (produto.Id == produtoAdicionar.Id && produto.QuantidadeProduto - quantidade < 0)
            {

            }
        }

        return falhas;
    }

    private static List<ValidacaoDominio> PodeFecharPedido(List<PedidoProduto> produtos)
    {
        List<ValidacaoDominio> falhas = new();

        if (produtos == null || produtos.Count == 0)
        {
            falhas.Add(new ValidacaoDominio(produtos.ToString(), "Não é possível fechar pedido sem produtos vinculados"));
        }

        foreach (var produto in produtos) 
        {
            if (produto.QuantidadeProduto <= 0) 
            {
                falhas.Add(new ValidacaoDominio(produtos.ToString(), $"Favor incluir uma quantidade ao produto {produto.ProdutoId}"));
            }
        }

        return falhas;
    }
}