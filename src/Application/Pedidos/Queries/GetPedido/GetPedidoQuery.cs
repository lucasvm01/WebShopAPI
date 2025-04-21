using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Queries.GetPedido;

public class GetPedidoQuery : IRequest<Pedido>
{
    public long PedidoId { get; set; }
}

public class GetPedidoQueryHandler : IRequestHandler<GetPedidoQuery, Pedido>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPedidoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Pedido> Handle(GetPedidoQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pedido>();

        var pedido = repository
            .FindBy(p => p.Id == request.PedidoId)
            .Include(x => x.Produtos)
            .FirstAsync(cancellationToken);

        return pedido;
    }
}