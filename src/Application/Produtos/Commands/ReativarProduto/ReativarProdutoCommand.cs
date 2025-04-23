using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.ReativarProduto;

public class ReativarProdutoCommand : IRequest<Unit>
{
    public long ProdutoId { get; set; }
}

public class ReativarProdutoCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<ReativarProdutoCommand, Unit>
{
    public async Task<Unit> Handle(ReativarProdutoCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        produto.ReativarProduto();

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}