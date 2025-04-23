namespace WebShopAPI.Domain.Validations;

public class ContextoValidacao
{
    private readonly List<ValidacaoDominio> _erros = new List<ValidacaoDominio>();

    public IReadOnlyList<ValidacaoDominio> Erros => _erros.AsReadOnly();

    public void AdicionarErro(string propriedade, string mensagem)
    {
        _erros.Add(new ValidacaoDominio(propriedade, mensagem));
    }

    public bool TemErros() => _erros.Any();
}