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

    public bool IsAtivo { get; private set; }
}