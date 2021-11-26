using beng.OrdersService.Application.Common;
using Dapr.Client;
using MediatR;

namespace beng.OrdersService.Application.Features.Orders.GetOrdersWithUserDependency
{
    public class GetOrdersQueryWithUserDependencyQueryHandler :
        IRequestHandler<GetOrdersQueryWithUserDependencyQuery, GetOrdersWithUserDependencyResponse>
    {
        private readonly IOrderRepository _repo;

        public GetOrdersQueryWithUserDependencyQueryHandler(IOrderRepository repo)
        {
            this._repo = repo;
        }

        public async Task<GetOrdersWithUserDependencyResponse> Handle(GetOrdersQueryWithUserDependencyQuery request,
            CancellationToken cancellationToken)
        {
            // buscar user e cenas e depois orders para o user
            var client = DaprClient.CreateInvokeHttpClient();

            var weatherForecasts =await client.GetFromJsonAsync<cenas>($"http://userservice/Users/get-by-name/coisas");

            return new GetOrdersWithUserDependencyResponse();
        }
    }

    internal class cenas
    {
        public string Name { get; set; }
    }
}