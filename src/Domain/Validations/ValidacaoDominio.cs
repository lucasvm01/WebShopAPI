namespace WebShopAPI.Domain.Validations;

public class ValidacaoDominio
{
    public ValidacaoDominio(string property, string message)
    {
        Propriedade = property;
        Mensagem = message;
    }

    public string Propriedade { get; }

    public string Mensagem { get; }

    public override string ToString()
    {
        return Propriedade + " : " + Mensagem;
    }
}

public static class Guard
{
    public static void Enforce(List<ValidacaoDominio> falhas)
    {
        if (falhas == null) return;
        if (falhas.Count == 0) return;
        throw new Exception(falhas.ToString());
    }
}