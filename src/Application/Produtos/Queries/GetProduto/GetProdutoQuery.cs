using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Produtos.Queries.GetProduto;

public class GetProdutoQuery : IRequest<ProdutoDto>
{
    public long ProdutoId { get; set; }
}

public class GetProdutoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetProdutoQuery, ProdutoDto>
{
    public async Task<ProdutoDto> Handle(GetProdutoQuery request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Produto>();

        var produto = await repository
            .FindBy(p => p.Id == request.ProdutoId)
            .FirstAsync(cancellationToken);

        var produtoDto = mapper.Map<ProdutoDto>(produto);

        return produtoDto;
    }
}