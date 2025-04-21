using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.ReativarProduto;

public class ReativarProdutoCommandValidator : ValidatorBase<ReativarProdutoCommand>
{
    public ReativarProdutoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.ProdutoId)
            .MustExist<ReativarProdutoCommand, Produto>(unitOfWork);
    }
}