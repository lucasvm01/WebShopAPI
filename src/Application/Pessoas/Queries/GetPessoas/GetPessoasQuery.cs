using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Queries.GetPessoas;

public class GetPessoasQuery : IRequest<List<Pessoa>>
{
}

public class GetPessoasQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPessoasQuery, List<Pessoa>>
{
    public async Task<List<Pessoa>> Handle(GetPessoasQuery request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pessoa>();

        var pessoas = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return pessoas;
    }
}