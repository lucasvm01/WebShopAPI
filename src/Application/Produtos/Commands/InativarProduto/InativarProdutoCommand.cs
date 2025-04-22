using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.InativarProduto;

public class InativarProdutoCommand : IRequest<Unit>
{
    public long ProdutoId { get; set; }
}
public class InativarProdutoCommandHandler : IRequestHandler<InativarProdutoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public InativarProdutoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(InativarProdutoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        produto.InativarProduto();

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}