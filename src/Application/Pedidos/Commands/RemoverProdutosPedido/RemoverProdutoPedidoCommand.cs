using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.RemoverProdutosPedido;

public class RemoverProdutoPedidoCommand : IRequest
{
    public long PedidoId { get; set; }

    public long ProdutoId { get; set; }
}
public class RemoverProdutoPedidoCommandHandler : IRequestHandler<RemoverProdutoPedidoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverProdutoPedidoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoverProdutoPedidoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pedido>();

        var pedido= await repository
            .FindBy(p => p.Id == request.PedidoId)
            .FirstAsync(cancellationToken);

        pedido.RemoverProduto(request.ProdutoId);

        await _unitOfWork.CommitAsync();
    }
}