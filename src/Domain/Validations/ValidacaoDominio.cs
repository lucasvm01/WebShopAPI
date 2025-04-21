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

    public static List<ValidacaoDominio> Init => new();
}

public static class Guard
{
    public static void Enforce(List<ValidacaoDominio> falhas)
    {
        if (falhas == null) return;
        if (falhas.Count == 0) return;
        throw new Exception(falhas.ToString());
    }

    public static void NotNull(object value, string propertyName)
    {
        Enforce(new List<ValidacaoDominio>().NotNull(
            value, propertyName, "O valor está vazio."));
    }

    public static List<ValidacaoDominio> NotNull(
        this List<ValidacaoDominio> source,
        object value,
        string propertyName,
        string message)
    {
        if (value != null) return source;
        source.Add(new ValidacaoDominio(propertyName, message));
        return source;
    }
}