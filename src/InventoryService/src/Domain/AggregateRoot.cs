namespace beng.InventoryService.Domain;

public abstract class AggregateRoot<T> : Entity<T>, IAuditableEntity
{
    public DateTime CreatedAtUtc { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public string? UpdatedBy { get; set; }
}