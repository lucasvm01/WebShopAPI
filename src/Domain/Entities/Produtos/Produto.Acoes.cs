using WebShopAPI.Domain.Validations;

namespace WebShopAPI.Domain.Entities.Produtos;

public partial class Produto
{
    public void CorrigirDescricao(string descricao)
    {
        Guard.Enforce(PodeCorrigirDescricaoProduto(descricao));

        Descricao = descricao;
    }

    public void AlterarQuantidade(long quantidade)
    {
        Guard.Enforce(PodeAlterarQuantidadeProduto(quantidade));

        QuantidadeTotal = quantidade;
    }

    public void AumentarQuantidade(long quantidadeAumentar)
    {
        Guard.Enforce(PodeAlterarQuantidadeProduto(quantidadeAumentar));

        QuantidadeTotal += quantidadeAumentar;
    }

    public void DiminuirQuantidade(long quantidadeDiminuir)
    {
        Guard.Enforce(PodeDiminuirQuantidadeProduto(QuantidadeTotal, quantidadeDiminuir));

        QuantidadeTotal -= quantidadeDiminuir;
    }

    public void ReativarProduto()
    {
        IsAtivo = true;
    }

    public void InativarProduto()
    {
        IsAtivo = false;
    }
}