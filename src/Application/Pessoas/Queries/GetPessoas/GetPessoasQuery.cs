using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Queries.GetPessoas;

public class GetPessoasQuery : IRequest<List<PessoaDto>>
{
}

public class GetPessoasQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) 
    : IRequestHandler<GetPessoasQuery, List<PessoaDto>>
{
    public async Task<List<PessoaDto>> Handle(GetPessoasQuery request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pessoa>();

        var pessoas = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        var pessoasDto = mapper.Map<List<PessoaDto>>(pessoas);

        return pessoasDto;
    }
}