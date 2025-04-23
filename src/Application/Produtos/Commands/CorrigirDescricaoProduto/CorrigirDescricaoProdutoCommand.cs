using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.CorrigirDescricaoProduto;

public class CorrigirDescricaoProdutoCommand : IRequest<Unit>
{
    public long ProdutoId { get; set; }

    public string Descricao { get; set; }
}

public class CorrigirDescricaoProdutoCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CorrigirDescricaoProdutoCommand, Unit>
{
    public async Task<Unit> Handle(CorrigirDescricaoProdutoCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        produto.CorrigirDescricao(request.Descricao);

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}