using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebShopAPI.Application.Produtos.Commands.CadastrarProduto;

namespace WebShopAPI.WebAPI.Controllers.Cadastro;

public class ProdutosController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastrar um novo produto.")]
    public async Task<IActionResult> PostProdutoAsync([FromBody] CadastrarProdutoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "produtos/", new
            {
                Succeeded = true,
                Message = "Produto cadastrado com sucesso.",
                Data = result,
            }
        );
    }
}