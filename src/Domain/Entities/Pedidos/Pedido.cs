using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces;
using WebShopAPI.Domain.Models.Pedidos;

namespace WebShopAPI.Domain.Entities.Pedidos;

public partial class Pedido : BaseEntity<long>, IAggregateRoot
{
    public Pedido(PedidoModel model) 
    {
        PessoaId = model.PessoaId;

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