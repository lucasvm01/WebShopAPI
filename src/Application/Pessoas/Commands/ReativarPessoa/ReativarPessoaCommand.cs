using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Commands.ReativarPessoa;

public class ReativarPessoaCommand : IRequest<Unit>
{
    public long PessoaId { get; set; }
}

public class ReativarPessoaCommandHandler : IRequestHandler<ReativarPessoaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public ReativarPessoaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(ReativarPessoaCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pessoa>();

        var pessoa = await repository
            .FindBy(p => p.Id == request.PessoaId)
            .FirstAsync(cancellationToken);

        pessoa.ReativarPessoa();

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}