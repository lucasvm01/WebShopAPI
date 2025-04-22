using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.AlterarQuantidadeProdutoPedido;

public class AlterarQuantidadeProdutoPedidoCommand : IRequest<Unit>
{
    public PedidoProdutoDTO PedidoProduto { get; set; }
}
public class AlterarQuantidadeProdutoPedidoCommandHandler : IRequestHandler<AlterarQuantidadeProdutoPedidoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public AlterarQuantidadeProdutoPedidoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AlterarQuantidadeProdutoPedidoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pedido>();

        var pedido = await repository
            .FindBy(p => p.Id == request.PedidoProduto.PedidoId)
            .FirstAsync(cancellationToken);

        pedido.AlterarQuantidadeProduto(request.PedidoProduto.ProdutoId, request.PedidoProduto.Quantidade);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}