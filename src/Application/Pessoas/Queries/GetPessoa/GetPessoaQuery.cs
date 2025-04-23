using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Queries.GetPessoa;

public class GetPessoaQuery : IRequest<Pessoa>
{
    public long PessoaId { get; set; }
}

public class GetPessoaQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPessoaQuery, Pessoa>
{
    public Task<Pessoa> Handle(GetPessoaQuery request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pessoa>();

        var pessoa = repository
            .FindBy(p => p.Id == request.PessoaId)
            .Include(p => p.Pedidos)
            .FirstAsync(cancellationToken);

        return pessoa;
    }
}