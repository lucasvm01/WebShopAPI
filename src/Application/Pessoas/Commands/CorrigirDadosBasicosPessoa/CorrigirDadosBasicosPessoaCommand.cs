using MediatR;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;
using WebShopAPI.Domain.Models.Pessoas;

namespace WebShopAPI.Application.Pessoas.Commands.CorrigirDadosBasicosPessoa;

public class CorrigirDadosBasicosPessoaCommand : IRequest<Unit>
{
    public long PessoaId { get; set; }

    public string Nome { get; set; }

    public string CPF { get; set; }

    public string Email { get; set; }

    public TipoPessoa TipoPessoa { get; set; }
}

public class CorrigirDadosBasicosPessoaCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CorrigirDadosBasicosPessoaCommand, Unit>
{
    public async Task<Unit> Handle(CorrigirDadosBasicosPessoaCommand request, CancellationToken cancellationToken)
    {
        var pessoaModel = CriarPessoaModel(request);

        var repository = unitOfWork.GetRepository<Pessoa>();

        var pessoa = await repository
            .FindBy(p => p.Id == request.PessoaId)
            .FirstAsync(cancellationToken);

        pessoa.CorrigirDadosBasicosPessoa(pessoaModel);

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }

    public PessoaModel CriarPessoaModel(CorrigirDadosBasicosPessoaCommand request)
    {
        var model = new PessoaModel
        {
            Nome = request.Nome,
            CPF = request.CPF,
            Email = request.Email,
            TipoPessoa = request.TipoPessoa,
        };

        return model;
    }
}