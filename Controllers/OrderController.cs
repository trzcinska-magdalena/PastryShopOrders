using Microsoft.AspNetCore.Mvc;
using PastryShopOrders.Services;

namespace PastryShopOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(string? clientLastName)
        {
            var orders = await _orderService.GetOrders(clientLastName);
            return Ok(orders);

        }
    }
}
