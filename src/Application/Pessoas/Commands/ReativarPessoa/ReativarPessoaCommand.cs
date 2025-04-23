using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Commands.ReativarPessoa;

public class ReativarPessoaCommand : IRequest<Unit>
{
    public long PessoaId { get; set; }
}

public class ReativarPessoaCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<ReativarPessoaCommand, Unit>
{
    public async Task<Unit> Handle(ReativarPessoaCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pessoa>();

        var pessoa = await repository
            .FindBy(p => p.Id == request.PessoaId)
            .FirstAsync(cancellationToken);

        pessoa.ReativarPessoa();

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}