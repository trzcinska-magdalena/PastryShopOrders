using Microsoft.AspNetCore.Mvc;
using PastryShopOrders.Models;
using PastryShopOrders.Models.DTOs;
using PastryShopOrders.Services;

namespace PastryShopOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IDbService _dbService;
        public ClientController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("{clientID}/orders")]
        public async Task<IActionResult> AddAOrder(int clientID, OrderPOST orderPOST)
        {
            if (!await _dbService.IsClientExist(clientID))
                return NotFound("Client doesn't exist!");
            if (!await _dbService.IsEmployeeExist(orderPOST.EmployeeID))
                return NotFound("Employee doesn't exist!");
 
            Order order = new Order()
            {
                AcceptedAt = orderPOST.AcceptedAt,
                Comments = orderPOST.Comments,
                ClientID = clientID
            };
            await _dbService.AddAOrder(order);

            foreach (var p in orderPOST.Pastries)
            {
                var pastry = await _dbService.GetPastryByName(p.Name);
                if (pastry is null)
                    return NotFound($"Pastry {p.Name} doesn't exist!");

                OrderPastry orderPastry = new OrderPastry()
                {
                    Amount = p.Amount,
                    Comme = p.Comments,
                    PastryID = pastry.ID,
                    Order = order,
                };
                await _dbService.AddOrderPastry(orderPastry);
            }            
            return Created("api/orders", "");
        }
    }
}
