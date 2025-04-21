using WebShopAPI.Domain.Models.Pessoas;

namespace WebShopAPI.Domain.Entities.Pessoas;

public partial class Pessoa
{
    public void DefinirTipoPessoa(TipoPessoaModel tipoPessoaModel)
    {
        TipoPessoa = new TipoPessoa(tipoPessoaModel);
    }

    public void CorrigirNome(string nome)
    {
        Nome = nome;
    }

    public void CorrigirCPF(string cpf)
    {
        CPF = cpf;
    }

    public void CorrigirEmail(string email)
    {
        Email = email;
    }

    public void AtivarPessoa()
    {
        IsAtivo = true;
    }

    public void InativarPessoa()
    {
        IsAtivo = false;
    }
}