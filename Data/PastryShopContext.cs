using Microsoft.EntityFrameworkCore;
using PastryShopOrders.Configurations;
using PastryShopOrders.Models;

namespace PastryShopOrders.Data
{
    public class PastryShopContext : DbContext
    {
        public DbSet<Client> clients { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Pastry> pastries { get; set; }
        public DbSet<OrderPastry> orderPastries { get; set; }

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
