﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Queries.GetPedidosFechados;

public class GetPedidosFechadosQuery : IRequest<List<PedidoDto>>
{
}

public class GetPedidosFechadosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetPedidosFechadosQuery, List<PedidoDto>>
{
    public async Task<List<PedidoDto>> Handle(GetPedidosFechadosQuery request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pedido>();

        var pedidos = await repository
            .GetAll()
            .Include(p => p.Pessoa)
            .Include(p => p.PedidoProdutos)
                .ThenInclude(x => x.Produto)
            .Where(p => p.DataFechamento != null)
            .ToListAsync(cancellationToken);

        var pedidoDtos = mapper.Map<List<PedidoDto>>(pedidos);

        return pedidoDtos;
    }
}