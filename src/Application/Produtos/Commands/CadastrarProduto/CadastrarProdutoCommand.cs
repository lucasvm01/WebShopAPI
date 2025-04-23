using MediatR;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Domain.Interfaces.Infrastructure;
using WebShopAPI.Domain.Models.Produtos;

namespace WebShopAPI.Application.Produtos.Commands.CadastrarProduto;

public class CadastrarProdutoCommand : IRequest<Produto>
{
    public string Descricao {  get; set; }

    public long QuantidadeTotal { get; set; }
}

public class CadastrarProdutoCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CadastrarProdutoCommand, Produto>
{
    public async Task<Produto> Handle(CadastrarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produtoModel = CriarProdutoModel(request);

        var produto = new Produto(produtoModel);

        var repository = unitOfWork.GetRepository<Produto>();

        repository.Add(produto);

        await unitOfWork.CommitAsync();

        return produto;
    }

    public ProdutoModel CriarProdutoModel(CadastrarProdutoCommand request)
    {
        var model = new ProdutoModel
        {
            Descricao = request.Descricao,
            QuantidadeTotal = request.QuantidadeTotal,
        };

        return model;
    }
}