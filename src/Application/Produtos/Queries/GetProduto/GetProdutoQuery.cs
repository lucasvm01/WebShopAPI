using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Queries.GetProduto;

public class GetProdutoQuery : IRequest<Produto>
{
    public long ProdutoId { get; set; }
}

public class GetProdutoQueryHandler : IRequestHandler<GetProdutoQuery, Produto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProdutoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Produto> Handle(GetProdutoQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Produto>();

        var produto = repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        return produto;
    }
}