namespace WebShopAPI.Domain.Entities.Pedidos;

public partial class Pedido : BaseEntity
{
    public Pedido(long id) : base(id)
    {
        IsAtivo = true;
    }

    //private Pedido()
    //{
    //    // Entity necessita de construtor vazio
    //}

    public bool IsAtivo { get; private set; }
}