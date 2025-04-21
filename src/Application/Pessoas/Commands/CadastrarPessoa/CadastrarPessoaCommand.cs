using MediatR;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Interfaces.Infrastructure;
using WebShopAPI.Domain.Models.Pessoas;

namespace WebShopAPI.Application.Pessoas.Commands.CadastrarPessoa;

public class CadastrarPessoaCommand : IRequest<Pessoa>
{
    public string Nome  { get; set; }

    public string CPF { get; set; }

    public string Email { get; set; }

    public TipoPessoa TipoPessoa { get; set; }
}

public class CadastrarPessoaCommandHandler : IRequestHandler<CadastrarPessoaCommand, Pessoa>
{
    private readonly IUnitOfWork _unitOfWork;

    public CadastrarPessoaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Pessoa> Handle(CadastrarPessoaCommand request, CancellationToken cancellationToken)
    {
        var pessoaModel = CriarPessoaModel(request);

        var pessoa = new Pessoa(pessoaModel);

        var repository = _unitOfWork.GetRepository<Pessoa>();

        repository.Add(pessoa);

        await _unitOfWork.CommitAsync();

        return pessoa;
    }

    public PessoaModel CriarPessoaModel(CadastrarPessoaCommand request)
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