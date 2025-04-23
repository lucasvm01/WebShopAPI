using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Queries.GetPessoa;

public class GetPessoaQuery : IRequest<PessoaDto>
{
    public long PessoaId { get; set; }
}

public class GetPessoaQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) 
    : IRequestHandler<GetPessoaQuery, PessoaDto>
{
    public async Task<PessoaDto> Handle(GetPessoaQuery request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pessoa>();

        var pessoa = await repository
            .FindBy(p => p.Id == request.PessoaId)
            .FirstAsync(cancellationToken);

        var pessoaDto = mapper.Map<PessoaDto>(pessoa);

        return pessoaDto;
    }
}