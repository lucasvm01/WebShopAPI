using FluentValidation;
using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.CorrigirDescricaoProduto;

public class CorrigirDescricaoProdutoCommandValidator : ValidatorBase<CorrigirDescricaoProdutoCommand>
{
    public CorrigirDescricaoProdutoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Descricao)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50);

        RuleFor(p => p.ProdutoId)
            .MustExist<CorrigirDescricaoProdutoCommand, Produto>(unitOfWork);
    }
}