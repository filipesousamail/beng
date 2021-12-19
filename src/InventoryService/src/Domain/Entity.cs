namespace beng.InventoryService.Domain;

public abstract class Entity<T>
{
    public T Id { get; init; }
}