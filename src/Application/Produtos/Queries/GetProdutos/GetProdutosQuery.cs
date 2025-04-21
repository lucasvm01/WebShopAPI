using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Queries.GetProdutos;

public class GetProdutosQuery : IRequest<List<Produto>>
{
}

public class GetProdutosQueryHandler : IRequestHandler<GetProdutosQuery, List<Produto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProdutosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Produto>> Handle(GetProdutosQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return produto;
    }
}