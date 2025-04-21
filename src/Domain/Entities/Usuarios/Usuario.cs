using WebShopAPI.Domain.Interfaces;

namespace WebShopAPI.Domain.Entities.Usuarios;

public partial class Usuario : BaseEntity<long>, IAggregateRoot
{
    private Usuario()
    {
        // Entity necessita de construtor privado vazio
    }

    public string Login { get; private set; }

    public string Senha { get; private set; }
    
    public Permissao Permissao { get; private set; }
}