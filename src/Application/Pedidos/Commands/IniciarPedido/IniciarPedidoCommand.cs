using MediatR;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.IniciarPedido;

public class IniciarPedidoCommand : IRequest<Pedido>
{
    public long PessoaId { get; set; }
}
public class IniciarPedidoCommandHandler : IRequestHandler<IniciarPedidoCommand, Pedido>
{
    private readonly IUnitOfWork _unitOfWork;

    public IniciarPedidoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Pedido> Handle(IniciarPedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = new Pedido(request.PessoaId);

        var repository = _unitOfWork.GetRepository<Pedido>();

        repository.Add(pedido);

        await _unitOfWork.CommitAsync();

        return pedido;
    }
}