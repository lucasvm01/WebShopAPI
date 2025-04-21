using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Commands.InativarPessoa;

public class InativarPessoaCommandValidator : ValidatorBase<InativarPessoaCommand>
{
    public InativarPessoaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.PessoaId)
            .MustExist<InativarPessoaCommand, Pessoa>(unitOfWork);
    }
}