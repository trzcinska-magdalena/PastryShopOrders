using Microsoft.EntityFrameworkCore;
using PastryShopOrders.Configurations;
using PastryShopOrders.Models;

namespace PastryShopOrders.Data
{
    public class PastryShopContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pastry> Pastries { get; set; }
        public DbSet<OrderPastry> OrderPastries { get; set; }

        public PastryShopContext(DbContextOptions options) : base(options)
        { }

        protected PastryShopContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new PastryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderPastryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
