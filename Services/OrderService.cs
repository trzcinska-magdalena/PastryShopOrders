using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PastryShopOrders.Data;
using PastryShopOrders.Models;
using PastryShopOrders.Models.DTOs;
using System.Linq;

namespace PastryShopOrders.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderWithAdditionalData>> GetOrders(string? clientLastName);
    }
    public class OrderService : IOrderService
    {
        private readonly PastryShopContext _context;

        public OrderService(PastryShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderWithAdditionalData>> GetOrders(string? clientLastName)
        {
            return await _context.Orders.Include(e => e.Client)
                                        .Include(e => e.OrderPastries)
                                        .ThenInclude(e => e.Pastry)
                                        .Where(e => e.Client.LastName == clientLastName)
                                        .Select(e => new OrderWithAdditionalData
                                        {
                                            ID = e.ID,
                                            AcceptedAt = e.AcceptedAt,
                                            FulfilledAt = e.FulfilledAt,
                                            Pastries = e.OrderPastries.Select(e => e.Pastry)
                                        })
                                        .ToListAsync();
            
        }
    }
}
