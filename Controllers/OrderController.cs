using Microsoft.AspNetCore.Mvc;
using PastryShopOrders.Models.DTOs;
using PastryShopOrders.Services;

namespace PastryShopOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IDbService _dbService;

        public OrderController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(string? clientLastName)
        {
            var orders = await _dbService.GetOrders(clientLastName);
            return Ok(orders);

        }
    }
}
