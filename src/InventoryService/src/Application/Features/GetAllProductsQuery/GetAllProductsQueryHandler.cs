using System.Linq.Dynamic.Core;
using beng.InventoryService.Infrastructure;
using beng.OrdersService.Application.Common;
using MediatR;

namespace beng.InventoryService.Application.Features.GetAllProductsQuery;

public record GetAllProductsQueryHandler(AppDbContext _db) :
    IRequestHandler<GetAllProductsQuery, PagedList<GetAllProductsQueryResult>>
{
    private readonly AppDbContext _db = _db;

    public Task<PagedList<GetAllProductsQueryResult>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var result = _db.Products
            .Select(GetAllProductsQueryResult.Projection)
            .OrderBy($"{request.OrderBy} {request.OrderDirection}")
            .TakePage(request.PageIndex, request.PageSize);

        return Task.FromResult(result);
    }
}