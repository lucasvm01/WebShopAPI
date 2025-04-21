using FluentValidation;
using WebShopAPI.Application.Common;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pedidos.Commands.AdicionarProdutosPedido;

public class AdicionarProdutoPedidoCommandValidator : ValidatorBase<AdicionarProdutoPedidoCommand>
{
    public AdicionarProdutoPedidoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.PedidoProduto.ProdutoId)
            .MustExist<AdicionarProdutoPedidoCommand, Produto>(unitOfWork);

        RuleFor(p => p.PedidoProduto.PedidoId)
            .MustExist<AdicionarProdutoPedidoCommand, Pedido>(unitOfWork);

        RuleFor(p => p.PedidoProduto.Quantidade)
            .GreaterThan(0);
    }
}