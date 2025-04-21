using FluentValidation;
using WebShopAPI.Application.Common;
using WebShopAPI.Application.Produtos.Commands.CorrigirDescricaoProduto;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.AumentarQuantidadeProduto;

public class AlterarQuantidadeProdutoCommandValidator : ValidatorBase<AlterarQuantidadeProdutoCommand>
{
    public AlterarQuantidadeProdutoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Quantidade)
            .GreaterThanOrEqualTo(0);

        RuleFor(p => p.ProdutoId)
            .MustExist<AlterarQuantidadeProdutoCommand, Produto>(unitOfWork);
    }
}