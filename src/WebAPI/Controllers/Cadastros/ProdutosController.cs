using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebShopAPI.Application.Produtos.Commands.AumentarQuantidadeProduto;
using WebShopAPI.Application.Produtos.Commands.CadastrarProduto;
using WebShopAPI.Application.Produtos.Commands.CorrigirDescricaoProduto;
using WebShopAPI.Application.Produtos.Commands.InativarProduto;
using WebShopAPI.Application.Produtos.Commands.ReativarProduto;
using WebShopAPI.Application.Produtos.Queries.GetProduto;
using WebShopAPI.Application.Produtos.Queries.GetProdutos;

namespace WebShopAPI.WebAPI.Controllers.Cadastro;

public class ProdutosController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastrar um novo produto.")]
    public async Task<IActionResult> PostCadastrarProdutoAsync([FromBody] CadastrarProdutoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created($"{result.Id}", result);
    }

    [HttpGet]
    [SwaggerOperation("Mostrar todas os produtos cadastrados.")]
    public async Task<IActionResult> GetProdutosAsync([FromQuery] GetProdutosQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }


    [HttpGet("{produtoId:long}")]
    [SwaggerOperation("Mostrar produto informado pelo identificador.")]
    public async Task<IActionResult> GetProdutoAsync([FromRoute] long produtoId, [FromQuery] GetProdutoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{produtoId:long}/corrigir-descricao")]
    [SwaggerOperation("Corrigir descrição de um produto informado pelo identificador.")]
    public async Task<IActionResult> PutCorrigirDescricaoProdutoAsync([FromRoute] long produtoId, [FromBody] CorrigirDescricaoProdutoCommand command)
    {
        if (produtoId != command.ProdutoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{produtoId:long}/alterar-quantidade")]
    [SwaggerOperation("Alterar a quantidade de um produto informado pelo identificador.")]
    public async Task<IActionResult> PutAlterarQuantidadeTotalProdutoAsync([FromRoute] long produtoId, [FromBody] AlterarQuantidadeTotalProdutoCommand command)
    {
        if (produtoId != command.ProdutoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{produtoId:long}/inativar")]
    [SwaggerOperation("Inativar uma pessoa informada pelo identificador.")]
    public async Task<IActionResult> PutInativarProdutoAsync([FromRoute] long produtoId, [FromBody] InativarProdutoCommand command)
    {
        if (produtoId != command.ProdutoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{produtoId:long}/ativar")]
    [SwaggerOperation("Reativar uma pessoa informada pelo identificador.")]
    public async Task<IActionResult> PutReativarProdutoAsync([FromRoute] long produtoId, [FromBody] ReativarProdutoCommand command)
    {
        if (produtoId != command.ProdutoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(result);
    }
}