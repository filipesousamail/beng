using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace beng.InventoryService.Api.IntegrationEventHandlers;

[ApiController]
[Route("integrations/v1/orders")]
public class OrderController:ControllerBase
{
    [HttpPost("order-created")]
    public async Task<IActionResult> OrderCreated([FromBody] OrderCreated request)
    {
        throw new NotImplementedException();
    }
}