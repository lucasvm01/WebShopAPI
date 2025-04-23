using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Queries.GetProdutos;

public class GetProdutosQuery : IRequest<List<ProdutoDto>>
{
}

public class GetProdutosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetProdutosQuery, List<ProdutoDto>>
{
    public async Task<List<ProdutoDto>> Handle(GetProdutosQuery request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Produto>();

        var produtos = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        var produtosDto = mapper.Map<List<ProdutoDto>>(produtos);

        return produtosDto;
    }
}