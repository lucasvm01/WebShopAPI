using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.ReativarProduto;

public class ReativarProdutoCommand : IRequest<Unit>
{
    public long ProdutoId { get; set; }
}
public class ReativarProdutoCommandHandler : IRequestHandler<ReativarProdutoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public ReativarProdutoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(ReativarProdutoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        produto.ReativarProduto();

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}