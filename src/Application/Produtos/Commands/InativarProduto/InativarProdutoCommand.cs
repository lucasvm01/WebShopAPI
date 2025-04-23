using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.InativarProduto;

public class InativarProdutoCommand : IRequest<Unit>
{
    public long ProdutoId { get; set; }
}

public class InativarProdutoCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<InativarProdutoCommand, Unit>
{
    public async Task<Unit> Handle(InativarProdutoCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        produto.InativarProduto();

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}