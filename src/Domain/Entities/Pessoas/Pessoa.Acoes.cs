﻿using WebShopAPI.Domain.Models.Pessoas;
using WebShopAPI.Domain.Validations;

namespace WebShopAPI.Domain.Entities.Pessoas;

public partial class Pessoa
{
    public void CorrigirDadosBasicosPessoa(PessoaModel pessoaModel)
    {
        Guard.Enforce(PodeDefinirPessoa(pessoaModel));

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