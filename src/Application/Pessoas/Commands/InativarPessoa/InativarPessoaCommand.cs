using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Commands.InativarPessoa;

public class InativarPessoaCommand : IRequest<Unit>
{
    public long PessoaId { get; set; }
}

public class InativarPessoaCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<InativarPessoaCommand, Unit>
{
    public async Task<Unit> Handle(InativarPessoaCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Pessoa>();

        var pessoa = await repository
            .FindBy(p => p.Id == request.PessoaId)
            .FirstAsync(cancellationToken);

        pessoa.InativarPessoa();

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}