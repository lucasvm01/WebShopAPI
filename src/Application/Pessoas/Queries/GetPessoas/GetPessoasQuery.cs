using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Application.Pessoas.Queries.GetPessoa;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Queries.GetPessoas;

public class GetPessoasQuery : IRequest<List<Pessoa>>
{
}

public class GetPessoasQueryHandler : IRequestHandler<GetPessoasQuery, List<Pessoa>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPessoasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Pessoa>> Handle(GetPessoasQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pessoa>();

        var pessoas = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return pessoas;
    }
}