using WebShopAPI.Domain.Entities.Pessoas;

namespace WebShopAPI.Domain.Models.Pessoas;

public class PessoaModel
{
    public string Nome { get; set; }

    public string CPF { get; set; }

    public string Email { get; set; }

    public TipoPessoa TipoPessoa { get; set; }
}