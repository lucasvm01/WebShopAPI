namespace WebShopAPI.Domain.Entities.Produtos;

public partial class Produto
{
    public void CorrigirDescricao(string descricao)
    {
        Descricao = descricao;
    }

    public void AlterarQuantidade(long quantidade)
    {
        Quantidade = quantidade;
    }

    public void AtivarProduto()
    {
        IsAtivo = true;
    }

    public void InativarProduto()
    {
        IsAtivo = false;
    }
}