using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces;
using WebShopAPI.Domain.Validations;

namespace WebShopAPI.Domain.Entities.Pedidos;

public partial class Pedido : BaseEntity<long>, IAggregateRoot
{
    public Pedido(Pessoa pessoa) 
    {
        Guard.Enforce(PodeIniciarPedido(pessoa));

        Pessoa = pessoa;

        DataAbertura = DateTime.Now;
        DataFechamento = null;
    }

    private Pedido()
    {
        // Entity necessita de construtor vazio
    }

    public DateTime DataAbertura { get; private set; }

    public DateTime? DataFechamento { get; private set; }

    public long PessoaId { get; private set; }

    public Pessoa Pessoa { get; private set; }

    public IReadOnlyCollection<PedidoProduto> Produtos => _produtos.AsReadOnly();
    private readonly List<PedidoProduto> _produtos = new();
}