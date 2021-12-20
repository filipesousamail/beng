namespace beng.InventoryService.Application.Features.CreateProduct;

public record CreateProductCommandRequest
{
    public string Name { get; set; }
    public Guid BrandId { get; set; }
    public Guid ColorId { get; set; }
    public Guid StatusId { get; set; }

    public CreateProductCommand ToCommand()
    {
        throw new NotImplementedException();
    }
}