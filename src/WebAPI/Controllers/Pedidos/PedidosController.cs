using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebShopAPI.Application.Pedidos.Commands.AdicionarProdutosPedido;
using WebShopAPI.Application.Pedidos.Commands.AlterarQuantidadeProdutoPedido;
using WebShopAPI.Application.Pedidos.Commands.FecharPedido;
using WebShopAPI.Application.Pedidos.Commands.IniciarPedido;
using WebShopAPI.Application.Pedidos.Commands.RemoverProdutosPedido;
using WebShopAPI.Application.Pedidos.Queries.GetPedido;
using WebShopAPI.Application.Pedidos.Queries.GetPedidos;
using WebShopAPI.Application.Pedidos.Queries.GetPedidosFechados;
using WebShopAPI.Application.Pedidos.Queries.GetPedidosIniciados;

namespace WebShopAPI.WebAPI.Controllers.Pedido;

[Route("api/[controller]")]
[ApiController]
public class PedidosController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Iniciar um pedido.")]
    public async Task<IActionResult> PostIniciarPedidoAsync([FromBody] IniciarPedidoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            $"{result.Id}", new
            {
                result.PessoaId,
                result.DataAbertura,
            }
        );
    }

    [HttpPut("{pedidoId:long}/fechar-pedido")]
    [SwaggerOperation("Fechar o pedido informado pelo identificador.")]
    public async Task<IActionResult> PutFecharPedidoAsync([FromRoute] long pedidoId, [FromBody] FecharPedidoCommand command)
    {
        if (pedidoId != command.PedidoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpGet]
    [SwaggerOperation("Mostrar todos os pedidos.")]
    public async Task<IActionResult> GetPedidosAsync([FromQuery] GetPedidosQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("iniciados")]
    [SwaggerOperation("Mostrar todos os pedidos iniciados.")]
    public async Task<IActionResult> GetPedidosIniciadosAsync([FromQuery] GetPedidosIniciadosQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("fechados")]
    [SwaggerOperation("Mostrar todos os pedidos fechados.")]
    public async Task<IActionResult> GetPedidosFechadosAsync([FromQuery] GetPedidosFechadosQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{pedidoId:long}")]
    [SwaggerOperation("Mostrar pedido informado pelo identificador e os produtos adicionados a ele.")]
    public async Task<IActionResult> GetProdutoAsync([FromRoute] long pedidoId, [FromQuery] GetPedidoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{pedidoId:long}/adicionar-produto")]
    [SwaggerOperation("Adicionar produto ao pedido informado pelo identificador.")]
    public async Task<IActionResult> PutAdicionarProdutoPedidoAsync([FromRoute] long pedidoId, [FromBody] AdicionarProdutoPedidoCommand command)
    {
        if (pedidoId != command.PedidoProduto.PedidoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{pedidoId:long}/remover-produto")]
    [SwaggerOperation("Remover produto ao pedido informado pelo identificador.")]
    public async Task<IActionResult> PutRemoverProdutoPedidoAsync([FromRoute] long pedidoId, [FromBody] RemoverProdutoPedidoCommand command)
    {
        if (pedidoId != command.ProdutoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{pedidoId:long}/alterar-quantidade-produto")]
    [SwaggerOperation("Alterar quantidade de um produto do pedido informado pelo identificador.")]
    public async Task<IActionResult> PutAlterarQuantidadeProdutoPedidoAsync([FromRoute] long pedidoId, [FromBody] AlterarQuantidadeProdutoPedidoCommand command)
    {
        if (pedidoId != command.PedidoProduto.PedidoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(result);
    }
}