using WebShopAPI.Domain.Entities.Usuarios;

namespace WebShopAPI.Domain.Models.Usuarios;

public class UsuarioModel
{
    public string Login { get; set; }

    public string Senha { get; set; }

    public Permissao Permissao { get; set; }
}