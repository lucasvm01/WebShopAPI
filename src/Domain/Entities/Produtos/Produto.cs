using WebShopAPI.Domain.Entities.Interfaces;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Models.Produtos;

namespace WebShopAPI.Domain.Entities.Produtos;

public partial class Produto : BaseEntity, IAggregateRoot
{
    public Produto(ProdutoModel model)
    {
        Descricao = model.Descricao;
        Quantidade = model.Quantidade;

        IsAtivo = true;
    }

    private Produto()
    {
        // Entity necessita de construtor privado vazio
    }

    public string Descricao { get; set; }

    public long Quantidade { get; private set; }

    public bool IsAtivo { get; private set; }

    public IReadOnlyCollection<Pedido> Pedidos => _pedidos.AsReadOnly();
    private readonly List<Pedido> _pedidos = new();
}