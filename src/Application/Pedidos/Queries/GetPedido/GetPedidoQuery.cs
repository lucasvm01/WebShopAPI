using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Queries.GetPedido;

public class GetPedidoQuery : IRequest<PedidoDto>
{
    public long PedidoId { get; set; }
}

public class GetPedidoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetPedidoQuery, PedidoDto>
{
    public async Task<PedidoDto> Handle(GetPedidoQuery request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pedido>();

        var pedido = await repository
            .FindBy(p => p.Id == request.PedidoId)
            .Include(p => p.Pessoa)
            .Include(p => p.PedidoProdutos)
                .ThenInclude(t => t.Produto)
            .FirstAsync(cancellationToken);

        var pedidoDto = mapper.Map<PedidoDto>(pedido);

        return pedidoDto;
    }
}