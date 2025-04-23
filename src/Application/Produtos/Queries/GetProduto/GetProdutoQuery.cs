using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Queries.GetProduto;

public class GetProdutoQuery : IRequest<Produto>
{
    public long ProdutoId { get; set; }
}

public class GetProdutoQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetProdutoQuery, Produto>
{
    public Task<Produto> Handle(GetProdutoQuery request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Produto>();

        var produto = repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        return produto;
    }
}