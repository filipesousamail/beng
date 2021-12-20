using MediatR;

namespace beng.OrdersService.Application.Features.Orders.PlaceOrder;

public record PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, PlaceOrderCommandResponse>
{
    public Task<PlaceOrderCommandResponse> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}