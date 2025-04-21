namespace WebShopAPI.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity(long id = default) 
    { 
        Id = id;
    }

    public long Id { get; set; }
}