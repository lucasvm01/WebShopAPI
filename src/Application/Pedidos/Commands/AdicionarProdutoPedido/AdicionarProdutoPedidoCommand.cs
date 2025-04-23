using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;
using WebShopAPI.Domain.Models.Pedidos;

namespace WebShopAPI.Application.Pedidos.Commands.AdicionarProdutosPedido;

public class AdicionarProdutoPedidoCommand : IRequest<Unit>
{
    public PedidoProdutoDTO PedidoProduto { get; set; }
}

public class AdicionarProdutosPedidoCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<AdicionarProdutoPedidoCommand, Unit>
{
    public async Task<Unit> Handle(AdicionarProdutoPedidoCommand request, CancellationToken cancellationToken)
    {
        var produtoAdicionar = await BuscarProduto(request.PedidoProduto.ProdutoId, cancellationToken);

        var pedidoProdutoModel = CriarPedidoProdutoModel(produtoAdicionar, request.PedidoProduto.Quantidade);

        var repository = unitOfWork.GetRepository<Pedido>();

        var pedido = await repository
            .FindBy(p => p.Id == request.PedidoProduto.PedidoId)
            .FirstAsync(cancellationToken);

        pedido.AdicionarProduto(pedidoProdutoModel);

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }

    public async Task<Produto> BuscarProduto(long produtoId, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == produtoId)
            .FirstAsync(cancellationToken);

        return produto;
    }

    public PedidoProdutoAdicionarModel CriarPedidoProdutoModel(Produto produto, long quantidade)
    {
        var model = new PedidoProdutoAdicionarModel
        {
            Produto = produto,
            Quantidade = quantidade,
        };

        return model;
    }
}