using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.ReativarProduto;

public class ReativarProdutoCommand : IRequest
{
    public long ProdutoId { get; set; }
}
public class ReativarProdutoCommandHandler : IRequestHandler<ReativarProdutoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public ReativarProdutoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ReativarProdutoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        produto.ReativarProduto();

        await _unitOfWork.CommitAsync();
    }
}