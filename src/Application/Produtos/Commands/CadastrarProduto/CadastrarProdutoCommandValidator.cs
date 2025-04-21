using FluentValidation;
using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.CadastrarProduto;

public class CadastrarProdutoCommandValidator : ValidatorBase<CadastrarProdutoCommand>
{
    public CadastrarProdutoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Descricao)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50);

        RuleFor(p => p.Quantidade)
            .GreaterThanOrEqualTo(0);
    }
}