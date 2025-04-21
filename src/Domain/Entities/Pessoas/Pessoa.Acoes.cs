using WebShopAPI.Domain.Models.Pessoas;

namespace WebShopAPI.Domain.Entities.Pessoas;

public partial class Pessoa
{
    public void DefinirTipoPessoa(TipoPessoa tipoPessoa)
    {
        TipoPessoa = tipoPessoa;
    }

    public void CorrigirDadosBasicosPessoa(PessoaModel pessoaModel)
    {
        Nome = pessoaModel.Nome;
        CPF = pessoaModel.CPF;
        Email = pessoaModel.Email;
        TipoPessoa = pessoaModel.TipoPessoa;
    }

    public void ReativarPessoa()
    {
        IsAtivo = true;
    }

    public void InativarPessoa()
    {
        IsAtivo = false;
    }
}