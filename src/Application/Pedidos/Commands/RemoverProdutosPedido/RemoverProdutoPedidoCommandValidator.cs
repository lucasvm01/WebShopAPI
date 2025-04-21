using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.RemoverProdutosPedido;

public class RemoverProdutoPedidoCommandValidator : ValidatorBase<RemoverProdutoPedidoCommand>
{
    public RemoverProdutoPedidoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.PedidoId)
            .MustExist<RemoverProdutoPedidoCommand, Pedido>(unitOfWork);

        RuleFor(p => p.ProdutoId)
            .MustExist<RemoverProdutoPedidoCommand, Produto>(unitOfWork);
    }
}