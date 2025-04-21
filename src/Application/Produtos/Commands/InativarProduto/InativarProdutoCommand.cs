using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Commands.InativarProduto;

public class InativarProdutoCommand : IRequest
{
    public long ProdutoId { get; set; }
}
public class InativarProdutoCommandHandler : IRequestHandler<InativarProdutoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public InativarProdutoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(InativarProdutoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        produto.InativarProduto();

        await _unitOfWork.CommitAsync();
    }
}