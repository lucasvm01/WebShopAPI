using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.IniciarPedido;

public class IniciarPedidoCommandValidator : ValidatorBase<IniciarPedidoCommand>
{
    public IniciarPedidoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.PessoaId)
            .MustExist<IniciarPedidoCommand, Pessoa>(unitOfWork);
    }
}