using MediatR;

namespace beng.OrdersService.Application.Features.Orders.GetOrder;

public record GetOrderByIdQueryHandler : IRequestHandler<GetOrderQuery, GetOrderQueryResult?>
{
    public Task<GetOrderQueryResult?> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}