using MediatR;

namespace beng.OrdersService.Application.Features.Orders.GetOrder;

public record GetOrderQuery : IRequest<GetOrderQueryResult?>
{
    public GetOrderQuery(Guid id)
    {
        throw new NotImplementedException();
    }
}