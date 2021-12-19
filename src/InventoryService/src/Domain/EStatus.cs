namespace beng.InventoryService.Domain;

public sealed record EStatus(Guid Id, string Name)
{
    public static EStatus PendingApproval => 
        new(Guid.Parse("a02711c5-a4da-42fb-918f-af06bf29c6c0"), "Pending Approval");
    public static EStatus InStock => new(Guid.Parse("f64675b8-38c3-4bca-b3a4-f807f9e5c6bf"), "In Stock");
    public static EStatus OutOfStock => new(Guid.Parse("27cfb36d-b4ce-44e4-b209-6d4b96c5a545"), "Out Of Stock");
}