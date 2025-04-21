using FluentValidation;
using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Commands.CorrigirDadosBasicosPessoa;

public class CorrigirDadosBasicosPessoaCommandValidator : ValidatorBase<CorrigirDadosBasicosPessoaCommand>
{
    public CorrigirDadosBasicosPessoaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
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

        RuleFor(p => p.TipoPessoa)
            .IsInEnum();
    }
}