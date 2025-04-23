using WebShopAPI.Domain.Models.Pessoas;
using WebShopAPI.Domain.Validations;

namespace WebShopAPI.Domain.Entities.Pessoas;

public partial class Pessoa
{
    private static List<ValidacaoDominio> PodeDefinirPessoa(PessoaModel model)
    {
        List<ValidacaoDominio> falhas = new();

        if(string.IsNullOrWhiteSpace(model.Nome))
        {
            falhas.Add(new ValidacaoDominio(model.Nome, "Campo está vazio"));
        }

        if (string.IsNullOrWhiteSpace(model.CPF))
        {
            falhas.Add(new ValidacaoDominio(model.CPF, "Campo está vazio"));
        }
        if (model.CPF.Length != 11)
        {
            falhas.Add(new ValidacaoDominio(model.CPF, "CPF inválido"));
        }

        if (string.IsNullOrWhiteSpace(model.Email))
        {
            falhas.Add(new ValidacaoDominio(model.Email, "Campo está vazio"));
        }

        if (!Enum.IsDefined(typeof(TipoPessoa), model.TipoPessoa))
        {
            falhas.Add(new ValidacaoDominio(model.TipoPessoa.ToString(), "Tipo da pessoa inválido"));
        }

        return falhas;
    }
}