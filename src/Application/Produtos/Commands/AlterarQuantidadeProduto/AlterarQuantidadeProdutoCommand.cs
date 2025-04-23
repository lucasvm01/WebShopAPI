using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.AumentarQuantidadeProduto;

public class AlterarQuantidadeTotalProdutoCommand : IRequest<Unit>
{
    public long ProdutoId { get; set; }

    public long QuantidadeTotal { get; set; }
}

public class AlterarQuantidadeTotalProdutoCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<AlterarQuantidadeTotalProdutoCommand, Unit>
{
    public async Task<Unit> Handle(AlterarQuantidadeTotalProdutoCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        produto.AlterarQuantidade(request.QuantidadeTotal);

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}