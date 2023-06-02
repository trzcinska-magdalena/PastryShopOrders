using Microsoft.EntityFrameworkCore;
using PastryShopOrders.Data;
using PastryShopOrders.Models;
using PastryShopOrders.Models.DTOs;

namespace PastryShopOrders.Services
{
    public interface IDbService
    {
        Task<IEnumerable<OrderWithAdditionalDataGET>> GetOrders(string? clientLastName);
        Task AddAOrder(Order order);
        Task AddOrderPastry(OrderPastry orderPastry);
        Task<Pastry?> GetPastryByName(string name);
        Task<bool> IsClientExist(int clientID);
        Task<bool> IsEmployeeExist(int employeeID);
    }
    public class DbService : IDbService
    {
        private readonly PastryShopContext _context;

        public DbService(PastryShopContext context)
        {
            _context = context;
        }

        public async Task AddAOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrderPastry(OrderPastry orderPastry)
        {
            await _context.OrderPastries.AddAsync(orderPastry);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderWithAdditionalDataGET>> GetOrders(string? clientLastName)
        {
            return await _context.Orders.Include(e => e.Client)
                                        .Include(e => e.OrderPastries)
                                        .ThenInclude(e => e.Pastry)
                                        .Where(e => e.Client.LastName == clientLastName || clientLastName == null)
                                        .Select(e => new OrderWithAdditionalDataGET
                                        {
                                            ID = e.ID,
                                            AcceptedAt = e.AcceptedAt,
                                            FulfilledAt = e.FulfilledAt,
                                            Pastries = e.OrderPastries.Select(e => new Pastry { ID = e.Pastry.ID, Name = e.Pastry.Name, Price = e.Pastry.Price })
                                        })
                                        .ToListAsync(); 
        }

        public async Task<Pastry?> GetPastryByName(string name)
        {
            return await _context.Pastries.Where(e => e.Name == name).FirstOrDefaultAsync();
        }

        public async Task<bool> IsClientExist(int clientID)
        {
            return await _context.Clients.Where(e => e.ID == clientID).CountAsync() > 0;
        }

        public async Task<bool> IsEmployeeExist(int employeeID)
        {
            return await _context.Employees.Where(e => e.ID == employeeID).CountAsync() > 0;
        }
    }
}
