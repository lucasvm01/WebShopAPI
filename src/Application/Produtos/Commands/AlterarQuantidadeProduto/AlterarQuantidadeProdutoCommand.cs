using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.AumentarQuantidadeProduto;

public class AlterarQuantidadeProdutoCommand : IRequest<Unit>
{
    public long ProdutoId { get; set; }

    public long Quantidade { get; set; }
}

public class AlterarQuantidadeProdutoCommandHandler : IRequestHandler<AlterarQuantidadeProdutoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public AlterarQuantidadeProdutoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AlterarQuantidadeProdutoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        produto.AlterarQuantidade(request.Quantidade);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}