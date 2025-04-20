using WebShopAPI.Domain.Entities.Pedidos;

namespace WebShopAPI.Domain.Entities.Pessoas;

public partial class Pessoa : BaseEntity
{
    public Pessoa(long id) : base(id)
    {
        IsAtivo = true;
    }

    //private Pessoa()
    //{
    //    // Entity necessita de construtor vazio
    //}

    public string Nome { get; private set; }

    public string CPF { get; private set; }

    public string Email { get; private set; }

    public TipoPessoa TipoPessoa { get; private set; }

    public bool IsAtivo { get; private set; }

    public IReadOnlyCollection<Pedido> Pedidos => _pedidos.AsReadOnly();
    private readonly List<Pedido> _pedidos = new();
}