using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.IniciarPedido;

public class IniciarPedidoCommand : IRequest<Pedido>
{
    public long PessoaId { get; set; }
}

public class IniciarPedidoCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<IniciarPedidoCommand, Pedido>
{
    public async Task<Pedido> Handle(IniciarPedidoCommand request, CancellationToken cancellationToken)
    {
        var pessoa = await BuscarPessoa(request.PessoaId, cancellationToken);

        var pedido = new Pedido(pessoa);

        var repository = unitOfWork.GetRepository<Pedido>();

        repository.Add(pedido);

        await unitOfWork.CommitAsync();

        return pedido;
    }

    public async Task<Pessoa> BuscarPessoa(long pessoaId, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pessoa>();

        var pessoa = await repository
            .FindBy(p => p.Id == pessoaId)
            .FirstAsync(cancellationToken);

        return pessoa;
    }
}