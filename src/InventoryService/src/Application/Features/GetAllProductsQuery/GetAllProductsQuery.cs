using beng.OrdersService.Application.Common;
using MediatR;

namespace beng.InventoryService.Application.Features.GetAllProductsQuery;

public record GetAllProductsQuery : IRequest<PagedList<GetAllProductsQueryResult>>
{
    public string? OrderBy { get; set; }
    public string? OrderDirection { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; } = 10;
}