using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.FecharPedido;

public class FecharPedidoCommand : IRequest<Unit>
{
    public long PedidoId { get; set; }
}

public class FecharPedidoCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<FecharPedidoCommand, Unit>
{
    public async Task<Unit> Handle(FecharPedidoCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pedido>();

        var pedido = await repository
            .FindBy(p => p.Id == request.PedidoId)
            .FirstAsync(cancellationToken);

        pedido.FecharPedido();

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}