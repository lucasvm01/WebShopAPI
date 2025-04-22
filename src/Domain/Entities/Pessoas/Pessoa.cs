using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces;
using WebShopAPI.Domain.Models.Pessoas;
using WebShopAPI.Domain.Validations;

namespace WebShopAPI.Domain.Entities.Pessoas;

public partial class Pessoa : BaseEntity<long>, IAggregateRoot
{
    public Pessoa(PessoaModel pessoaModel)
    {
        Guard.Enforce(PodeDefinirPessoa(pessoaModel));

        Nome = pessoaModel.Nome;
        CPF = pessoaModel.CPF;
        Email = pessoaModel.Email;
        TipoPessoa = pessoaModel.TipoPessoa;

        IsAtivo = true;
    }

    private Pessoa()
    {
        // Entity necessita de construtor vazio
    }

    public string Nome { get; private set; }

    public string CPF { get; private set; }

    public string Email { get; private set; }

    public TipoPessoa TipoPessoa { get; private set; }

    public bool IsAtivo { get; private set; }

    public IReadOnlyCollection<Pedido> Pedidos => _pedidos.AsReadOnly();
    private readonly List<Pedido> _pedidos = new();
}