using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Pessoas.Commands.InativarPessoa;

public class InativarPessoaCommand : IRequest<Unit>
{
    public long PessoaId { get; set; }
}


public class InativarPessoaCommandHandler : IRequestHandler<InativarPessoaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public InativarPessoaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(InativarPessoaCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pessoa>();

        var pessoa = await repository
            .FindBy(p => p.Id == request.PessoaId)
            .FirstAsync(cancellationToken);

        pessoa.InativarPessoa();

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}