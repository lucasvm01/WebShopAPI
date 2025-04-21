namespace WebShopAPI.Domain.Entities.Usuarios;

public partial class Usuario
{
    public void CorrigirLogin(string login)
    {
        Login = login;
    }

    public void CorrigirSenha(string senha)
    {
        Senha = senha;
    }

    public void CorrigirPermissao(Permissao permissao)
    {
        Permissao = permissao;
    }
}