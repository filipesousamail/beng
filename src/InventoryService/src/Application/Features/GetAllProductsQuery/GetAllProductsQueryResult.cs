using System.Linq.Expressions;
using beng.InventoryService.Domain;
using beng.InventoryService.Domain.Products;

namespace beng.InventoryService.Application.Features.GetAllProductsQuery;

public record GetAllProductsQueryResult()
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public Guid BrandId { get; init; }
    public string Brand { get; init; }
    public Guid ColorId { get; init; }
    public string Color { get; init; }
    public Guid StatusId { get; init; }
    public string Status { get; init; }


    public static readonly Expression<Func<Product, GetAllProductsQueryResult>> Projection = e =>
        new GetAllProductsQueryResult
        {
            Id = e.Id,
            Name = e.Name,
            BrandId = e.BrandId,
            Brand = e.Brand.Name,
            ColorId = e.ColorId,
            Color = e.Color.Name,
            StatusId = e.StatusId,
            Status = e.Status.Name
        };
}