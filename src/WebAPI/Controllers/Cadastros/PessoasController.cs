using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebShopAPI.Application.Pessoas.Commands.CadastrarPessoa;
using WebShopAPI.Application.Pessoas.Commands.CorrigirDadosBasicosPessoa;
using WebShopAPI.Application.Pessoas.Commands.InativarPessoa;
using WebShopAPI.Application.Pessoas.Commands.ReativarPessoa;
using WebShopAPI.Application.Pessoas.Queries.GetPessoa;
using WebShopAPI.Application.Pessoas.Queries.GetPessoas;

namespace WebShopAPI.WebAPI.Controllers.Cadastro;

public class PessoasController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastrar uma nova pessoa.")]
    public async Task<IActionResult> PostCadastrarPessoaAsync([FromBody] CadastrarPessoaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "pessoas/", new
            {
                Succeeded = true,
                Message = "Pessoa cadastrada com sucesso.",
                Data = result,
            }
        );
    }

    [HttpGet]
    [SwaggerOperation("Mostrar todas as pessoas cadastradas.")]
    public async Task<IActionResult> GetPessoasAsync([FromBody] GetPessoasQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }


    [HttpGet("{pessoaId:long}")]
    [SwaggerOperation("Mostrar pessoa informada pelo identificador.")]
    public async Task<IActionResult> GetPessoaAsync([FromRoute] long pessoaId, GetPessoaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{pessoaId:long}/corrigir-dados-basicos")]
    [SwaggerOperation("Corrigir os dados básicos de pessoa informada pelo identificador.")]
    public async Task<IActionResult> PutCorrigirDadosPessoaisPessoaAsync([FromRoute] long pessoaId, [FromBody] CorrigirDadosBasicosPessoaCommand command)
    {
        if (pessoaId != command.PessoaId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{pessoaId:long}/inativar")]
    [SwaggerOperation("Inativar uma pessoa informada pelo identificador.")]
    public async Task<IActionResult> PutInativarPessoaAsync([FromRoute] long pessoaId, [FromBody] InativarPessoaCommand command)
    {
        if (pessoaId != command.PessoaId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{pessoaId:long}/ativar")]
    [SwaggerOperation("Reativar uma pessoa informada pelo identificador.")]
    public async Task<IActionResult> PutReativarPessoaAsync([FromRoute] long pessoaId, [FromBody] ReativarPessoaCommand command)
    {
        if (pessoaId != command.PessoaId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(result);
    }
}