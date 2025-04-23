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

    private static List<ValidacaoDominio> PodeAlterarQuantidadeProduto(long quantidade)
    {
        List<ValidacaoDominio> falhas = new();

        if (quantidade < 0)
        {
            falhas.Add(new ValidacaoDominio(quantidade.ToString(), "Quantidade deve ser maior ou igual a zero"));
        }

        return falhas;
    }

    private static List<ValidacaoDominio> PodeRemoverProduto(PedidoProduto? produtoAdicionar, DateTime? DataFechamento)
    {
        List<ValidacaoDominio> falhas = new();

        if (DataFechamento != null)
        {
            falhas.Add(new ValidacaoDominio(DataFechamento.ToString(), "O pedido deve estar aberto"));
        }

        if (produtoAdicionar == null)
        {
            falhas.Add(new ValidacaoDominio(produtoAdicionar.ToString(), "Campo está vazio"));
        }

        return falhas;
    }

    private static List<ValidacaoDominio> PodeFecharPedido(List<PedidoProduto> pedidoProdutos, DateTime? DataFechamento)
    {
        List<ValidacaoDominio> falhas = new();

        if (DataFechamento != null)
        {
            falhas.Add(new ValidacaoDominio(pedidoProdutos.ToString(), "Pedido já está fechado"));
        }

        if (pedidoProdutos == null)
        {
            falhas.Add(new ValidacaoDominio(pedidoProdutos.ToString(), "Não é possível fechar pedido sem produtos vinculados"));
        }

        foreach (var pedidoProduto in pedidoProdutos) 
        {
            if (!PodeRetirarQuantidadeTotalProduto(pedidoProduto.Produto.QuantidadeTotal, pedidoProduto.QuantidadeProduto)) 
            {
                falhas.Add(new ValidacaoDominio(pedidoProdutos.ToString(), "Não há quantidade do produto suficiente"));
            }
        }

        return falhas;
    }

    private static List<ValidacaoDominio> PedidoIsAtivo(DateTime? dataFechamento)
    {
        List<ValidacaoDominio> falhas = new();

        if (dataFechamento != null)
        {
            falhas.Add(new ValidacaoDominio(dataFechamento.ToString(), "Produto não está ativo"));
        }

        return falhas;
    }

    private static bool PodeRetirarQuantidadeTotalProduto(long quantidadeTotalProduto, long quantidadeRetirar)
    {
        return quantidadeTotalProduto > quantidadeRetirar;
    }
}