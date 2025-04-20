using WebShopAPI.Domain.Entities.Pedidos;

namespace WebShopAPI.Domain.Entities.Produtos;

public partial class Produto : BaseEntity
{
    public Produto(long id) : base(id)
    {
        IsAtivo = true;
    }

    //private Produto()
    //{
    //    // Entity necessita de construtor privado vazio
    //}

    public string Descricao { get; set; }

    public long Quantidade { get; private set; }

    public bool IsAtivo { get; private set; }

    public IReadOnlyCollection<Pedido> Pedidos => _pedidos.AsReadOnly();
    private readonly List<Pedido> _pedidos = new();
}