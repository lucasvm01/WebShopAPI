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

    public bool IsAtivo { get; private set; }

    public TipoPessoa TipoPessoa { get; private set; }
}