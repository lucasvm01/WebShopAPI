using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.AlterarQuantidadeProdutoPedido;

public class AlterarQuantidadeProdutoPedidoCommand : IRequest<Unit>
{
    public PedidoProdutoDTO PedidoProduto { get; set; }
}

public class AlterarQuantidadeProdutoPedidoCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<AlterarQuantidadeProdutoPedidoCommand, Unit>
{
    public async Task<Unit> Handle(AlterarQuantidadeProdutoPedidoCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pedido>();

        var pedido = await repository
            .FindBy(p => p.Id == request.PedidoProduto.PedidoId)
            .FirstAsync(cancellationToken);

        pedido.AlterarQuantidadeProduto(request.PedidoProduto.ProdutoId, request.PedidoProduto.Quantidade);

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}