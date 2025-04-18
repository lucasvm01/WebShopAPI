namespace WebShopAPI.Domain.Entities.Pessoas;

public partial class TipoPessoa
{
    public TipoPessoa() 
    {
    }

    //private Produto()
    //{
    //    // Entity necessita de construtor privado vazio
    //}

    public bool IsCliente { get; private set; }

    public bool IsFuncionario { get; private set; }
}