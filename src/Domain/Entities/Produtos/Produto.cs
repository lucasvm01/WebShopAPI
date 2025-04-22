using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces;
using WebShopAPI.Domain.Models.Produtos;
using WebShopAPI.Domain.Validations;

namespace WebShopAPI.Domain.Entities.Produtos;

public partial class Produto : BaseEntity<long>, IAggregateRoot
{
    public Produto(ProdutoModel produtoModel)
    {
        Guard.Enforce(PodeCadastrarProduto(produtoModel));

        Descricao = produtoModel.Descricao;
        Quantidade = produtoModel.Quantidade;

        IsAtivo = true;
    }

    private Produto()
    {
        // Entity necessita de construtor privado vazio
    }

    public string Descricao { get; set; }

    public long Quantidade { get; private set; }

    public bool IsAtivo { get; private set; }

    public IReadOnlyCollection<PedidoProduto> Pedidos => _pedidos.AsReadOnly();
    private readonly List<PedidoProduto> _pedidos = new();
}