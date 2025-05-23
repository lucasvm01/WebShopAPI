﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Queries.GetPedidos;

public class GetPedidosQuery : IRequest<List<PedidoDto>>
{
}

public class GetPedidosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetPedidosQuery, List<PedidoDto>>
{
    public async Task<List<PedidoDto>> Handle(GetPedidosQuery request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pedido>();

        var pedidos = await repository
            .GetAll()
            .Include(p => p.Pessoa)
            .Include(p => p.PedidoProdutos)
                .ThenInclude(x => x.Produto)
            .ToListAsync(cancellationToken);

        var pedidoDtos = mapper.Map<List<PedidoDto>>(pedidos);

        return pedidoDtos;
    }
}