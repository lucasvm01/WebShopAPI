using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.InativarProduto;

public class InativarProdutoCommandValidator : ValidatorBase<InativarProdutoCommand>
{
    public InativarProdutoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.ProdutoId)
            .MustExist<InativarProdutoCommand, Produto>(unitOfWork);
    }
}