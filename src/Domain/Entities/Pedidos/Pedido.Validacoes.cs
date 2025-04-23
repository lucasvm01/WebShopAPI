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
        if (!pessoa.IsAtivo)
        {
            falhas.Add(new ValidacaoDominio(pessoa.ToString(), "O cliente deve estar ativo"));
        }

        return falhas;
    }

    private static List<ValidacaoDominio> PodeAdicionarProduto(Produto produtoAdicionar, long quantidade)
    {
        List<ValidacaoDominio> falhas = new();

        if (produtoAdicionar == null)
        {
            falhas.Add(new ValidacaoDominio(produtoAdicionar.ToString(), "Campo está vazio"));
        }

        if (!produtoAdicionar.IsAtivo)
        {
            falhas.Add(new ValidacaoDominio(produtoAdicionar.ToString(), "O produto deve estar ativo"));
        }

        if (!PodeRetirarQuantidadeTotalProduto(produtoAdicionar.QuantidadeTotal, quantidade))
        {
            falhas.Add(new ValidacaoDominio(
                produtoAdicionar.ToString(),
                $"Não há quantidade do produto {produtoAdicionar.Descricao} o suficiente para adicionar ao pedido"));
        }

        return falhas;
    }

    private static List<ValidacaoDominio> PodeRemoverProduto(Produto produtoAdicionar, long quantidade, List<PedidoProduto> produtos)
    {
        List<ValidacaoDominio> falhas = new();

        if (produtoAdicionar == null)
        {
            falhas.Add(new ValidacaoDominio(produtoAdicionar.ToString(), "Campo está vazio"));
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

        foreach (var pedidoProduto in produtos) 
        {
            if (!PodeRetirarQuantidadeTotalProduto(pedidoProduto.Produto.QuantidadeTotal, pedidoProduto.QuantidadeProduto)) 
            {
                falhas.Add(new ValidacaoDominio(produtos.ToString(), "Não há quantidade do produto suficiente"));
            }
        }

        return falhas;
    }

    private static List<ValidacaoDominio> PedidoNotIsAtivo(DateTime dataAbertura, DateTime? dataFechamento)
    {
        List<ValidacaoDominio> falhas = new();

        if (dataFechamento != null)
        {
            falhas.Add(new ValidacaoDominio(dataAbertura.ToString(), "Não há quantidade do produto suficiente"));
        }

        return falhas;
    }

    private static bool PodeRetirarQuantidadeTotalProduto(long quantidadeTotalProduto, long quantidadeRetirar)
    {
        return quantidadeTotalProduto > quantidadeRetirar;
    }
}