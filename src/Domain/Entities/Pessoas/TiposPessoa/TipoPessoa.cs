using WebShopAPI.Domain.Models.Pessoas;

namespace WebShopAPI.Domain.Entities.Pessoas;

public partial class TipoPessoa
{
    public TipoPessoa(TipoPessoaModel model)
    {
        IsCliente = model.IsCliente;
        IsFuncionario = model.IsFuncionario;
    }

    //private TipoPessoa()
    //{
    //    // Entity necessita de construtor privado vazio
    //}

    public bool IsCliente { get; private set; }

    public bool IsFuncionario { get; private set; }
}