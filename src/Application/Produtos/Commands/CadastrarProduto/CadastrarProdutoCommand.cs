using MediatR;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;
using WebShopAPI.Domain.Models.Produtos;

namespace WebShopAPI.Application.Produtos.Commands.CadastrarProduto;

public class CadastrarProdutoCommand : IRequest<Produto>
{
    public string Descricao {  get; set; }

    public long Quantidade { get; set; }
}

public class CadastrarProdutoCommandHandler : IRequestHandler<CadastrarProdutoCommand, Produto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CadastrarProdutoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Produto> Handle(CadastrarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produtoModel = CriarProdutoModel(request);

        var produto = new Produto(produtoModel);

        var repository = _unitOfWork.GetRepository<Produto>();

        repository.Add(produto);

        await _unitOfWork.CommitAsync();

        return produto;
    }

    public ProdutoModel CriarProdutoModel(CadastrarProdutoCommand request)
    {
        var model = new ProdutoModel
        {
            Descricao = request.Descricao,
            Quantidade = request.Quantidade,
        };

        return model;
    }
}