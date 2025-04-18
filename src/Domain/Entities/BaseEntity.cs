namespace WebShopAPI.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity(long id) 
    { 
        Id = id;
    }

    public long Id { get; set; }
}