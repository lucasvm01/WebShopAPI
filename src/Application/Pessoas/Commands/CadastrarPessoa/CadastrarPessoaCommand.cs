using MediatR;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Entities.Pessoas.TiposPessoa;

namespace WebShopAPI.Application.Pessoas.Commands.CadastrarPessoa;

public class CadastrarPessoaCommand : IRequest<Pessoa>
{
    public string Nome  { get; set; }

    public string CPF { get; set; }

    public string Email { get; set; }

    public TipoPessoa TipoPessoa { get; set; }
}

public class CadastrarPessoaCommandValidator : IRequestHandler<CadastrarPessoaCommand, Pessoa>
{


}