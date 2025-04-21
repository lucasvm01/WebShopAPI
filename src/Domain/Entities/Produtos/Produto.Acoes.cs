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

    public void AumentarQuantidade(long quantidadeAumentar)
    {
        Quantidade += quantidadeAumentar;
    }

    public void DiminuirQuantidade(long quantidadeDiminuir)
    {
        Quantidade -= quantidadeDiminuir;
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