namespace beng.InventoryService.Application.Features.IncreaseInventory;

public record IncreaseInventoryCommandRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}