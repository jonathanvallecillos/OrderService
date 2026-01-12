using Microsoft.AspNetCore.Mvc;
using OrderService.Application.UseCases;

namespace OrderService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateOrderRequest request,
            [FromServices] CreateOrderUseCase useCase
        )
        {
            var id = await useCase.ExecuteAsync(request.Total);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(
            Guid id,
            [FromServices] GetOrderByIdUseCase useCase
        )
        {
            var order = await useCase.ExecuteAsync(id);

            if (order is null)
                return NotFound();

            return Ok(order);
        }
    }

    public record CreateOrderRequest(decimal Total);
}
