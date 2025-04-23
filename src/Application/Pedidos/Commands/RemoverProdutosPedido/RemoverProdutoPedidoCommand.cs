using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.RemoverProdutosPedido;

public class RemoverProdutoPedidoCommand : IRequest<Unit>
{
    public long PedidoId { get; set; }

    public long ProdutoId { get; set; }
}

public class RemoverProdutoPedidoCommandHandler(IUnitOfWork unitOfWork) 
    : IRequestHandler<RemoverProdutoPedidoCommand, Unit>
{

    public async Task<Unit> Handle(RemoverProdutoPedidoCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pedido>();

        var pedido= await repository
            .FindBy(p => p.Id == request.PedidoId)
            .FirstAsync(cancellationToken);

        pedido.RemoverProduto(request.ProdutoId);

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}