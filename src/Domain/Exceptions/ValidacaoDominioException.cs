using WebShopAPI.Domain.Validations;

namespace WebShopAPI.Domain.Exceptions;

public class ValidacaoDominioException : Exception
{
    public List<ValidacaoDominio> Erros { get; }

    public ValidacaoDominioException(List<ValidacaoDominio> erros)
        : base("Ocorreram erros de validação no domínio.")
    {
        Erros = erros ?? new List<ValidacaoDominio>();
    }
}