using FluentValidation;
using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Commands.CadastrarPessoa;

public class CadastrarPessoaCommandValidator : ValidatorBase<CadastrarPessoaCommand>
{
    public CadastrarPessoaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50);

        RuleFor(p => p.CPF)
            .NotEmpty()
            .Length(11);

        RuleFor(p => p.Email)
            .MaximumLength(50);
    }
}