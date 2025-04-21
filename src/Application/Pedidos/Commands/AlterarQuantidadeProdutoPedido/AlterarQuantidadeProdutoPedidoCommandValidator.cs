using FluentValidation;
using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.AlterarQuantidadeProdutoPedido;

public class AlterarQuantidadeProdutoPedidoCommandValidator : ValidatorBase<AlterarQuantidadeProdutoPedidoCommand>
{
    public AlterarQuantidadeProdutoPedidoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.PedidoProduto.ProdutoId)
            .MustExist<AlterarQuantidadeProdutoPedidoCommand, Produto>(unitOfWork);

        RuleFor(p => p.PedidoProduto.PedidoId)
            .MustExist<AlterarQuantidadeProdutoPedidoCommand, Pedido>(unitOfWork);

        RuleFor(p => p.PedidoProduto.Quantidade)
            .GreaterThan(0);
    }
}