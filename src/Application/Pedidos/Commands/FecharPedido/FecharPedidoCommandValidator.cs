using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.FecharPedido;

public class FecharPedidoCommandValidator : ValidatorBase<FecharPedidoCommand>
{
    public FecharPedidoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.PedidoId)
            .MustExist<FecharPedidoCommand, Pedido>(unitOfWork);
    }
}