using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebShopAPI.Domain.Models.Pessoas;

public class PessoaModel
{
    public string Nome { get; set; }

    public string CPF { get; set; }

    public string Email { get; set; }

    public TipoPessoaModel TipoPessoa { get; set; }
}-