using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebShopAPI.Application.Pessoas.Commands.CadastrarPessoa;

namespace WebShopAPI.WebAPI.Controllers.Cadastro;

public class PessoasController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastrar uma nova pessoa.")]
    public async Task<IActionResult> PostPessoaAsync([FromBody] CadastrarPessoaCommand command)
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
}