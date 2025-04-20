using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Entities.Produtos;

namespace WebShopAPI.Domain.Entities.Pedidos;

public partial class Pedido : BaseEntity
{
    public Pedido(long id) : base(id)
    {
        DataAbertura = DateTime.Now;
        DataFechamento = null;
    }

    //private Pedido()
    //{
    //    // Entity necessita de construtor vazio
    //}
    
    public DateTime DataAbertura { get; private set; }

    public DateTime? DataFechamento { get; private set; }

    public long PessoaId { get; private set; }

    public Pessoa Pessoa { get; private set; }

    public IReadOnlyCollection<Produto> Produtos => _produtos.AsReadOnly();
    private readonly List<Produto> _produtos = new();
}