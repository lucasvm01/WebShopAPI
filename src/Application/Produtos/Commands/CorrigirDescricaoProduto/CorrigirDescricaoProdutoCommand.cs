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
public class CorrigirDescricaoProdutoCommandHandler : IRequestHandler<CorrigirDescricaoProdutoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirDescricaoProdutoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirDescricaoProdutoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        produto.CorrigirDescricao(request.Descricao);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}