using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.FecharPedido;

public class FecharPedidoCommand : IRequest
{
    public long PedidoId { get; set; }
}
public class FecharPedidoCommandHandler : IRequestHandler<FecharPedidoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public FecharPedidoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(FecharPedidoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pedido>();

        var pedido = await repository
            .FindBy(p => p.Id == request.PedidoId)
            .FirstAsync(cancellationToken);

        pedido.FecharPedido();

        await _unitOfWork.CommitAsync();
    }
}