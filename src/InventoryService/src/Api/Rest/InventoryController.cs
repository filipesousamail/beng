using beng.InventoryService.Application.Features.IncreaseInventory;
using Microsoft.AspNetCore.Mvc;

namespace beng.InventoryService.Api.Rest;

[ApiController]
[Route("integrations/v1/products")] // ??
public class InventoryController : ControllerBase
{
    [HttpPut]
    [Route("{productId:guid}")]
    public async Task<IActionResult> Increase([FromRoute] Guid productId,
        [FromBody] IncreaseInventoryCommandRequest request)
    {
        throw new NotImplementedException();
    }
}