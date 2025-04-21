using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Queries.GetPedidos;

public class GetPedidosQuery : IRequest<List<Pedido>>
{
}
public class GetPedidosQueryHandler : IRequestHandler<GetPedidosQuery, List<Pedido>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPedidosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Pedido>> Handle(GetPedidosQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pedido>();

        var pedido = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return pedido;
    }
}