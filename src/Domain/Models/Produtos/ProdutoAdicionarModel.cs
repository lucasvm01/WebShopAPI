namespace WebShopAPI.Domain.Models.Produtos;

public class ProdutoAdicionarModel
{
    public string ProdutoId { get; set; } 

    public string Descricao { get; set; }

    public long Quantidade { get; set; }
}