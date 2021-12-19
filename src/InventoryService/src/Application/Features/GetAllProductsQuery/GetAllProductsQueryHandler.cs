using beng.OrdersService.Application.Common;
using MediatR;

namespace beng.InventoryService.Application.Features.GetAllProductsQuery;

public record GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedList<GetAllProductsQueryResult>>
{
    public Task<PagedList<GetAllProductsQueryResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}