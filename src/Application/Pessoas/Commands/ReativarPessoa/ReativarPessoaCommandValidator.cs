using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Commands.ReativarPessoa;

public class ReativarPessoaCommandValidator : ValidatorBase<ReativarPessoaCommand>
{
    protected ReativarPessoaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.PessoaId)
            .MustExist<ReativarPessoaCommand, Pessoa>(unitOfWork);
    }
}