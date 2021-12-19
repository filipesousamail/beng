namespace beng.InventoryService.Application.Features.GetAllProductsQuery;

public record GetAllProductsQueryRequest
{
    public string? OrderBy { get; set; }
    public string? OrderDirection { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; } = 10;

    public GetAllProductsQuery ToQuery() =>
        new()
        {
            OrderBy = OrderBy,
            OrderDirection = OrderDirection,
            PageIndex = PageIndex,
            PageSize = PageSize
        };
}