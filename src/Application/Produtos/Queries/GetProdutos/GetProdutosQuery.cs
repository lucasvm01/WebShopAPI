using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Queries.GetProdutos;

public class GetProdutosQuery : IRequest<List<Produto>>
{
}

public class GetProdutosQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetProdutosQuery, List<Produto>>
{
    public async Task<List<Produto>> Handle(GetProdutosQuery request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Produto>();

        var produtos = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return produtos;
    }
}