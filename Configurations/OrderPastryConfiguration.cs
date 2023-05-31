using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PastryShopOrders.Models;

namespace PastryShopOrders.Configurations
{
    public class OrderPastryConfiguration : IEntityTypeConfiguration<OrderPastry>
    {
        public void Configure(EntityTypeBuilder<OrderPastry> entity)
        {
            entity.ToTable("Order_Pastry");
            entity.HasKey(e => new { e.OrderID, e.PastryID });

            entity.Property(e => e.Amount).IsRequired();
            entity.Property(e => e.Comme).HasMaxLength(300);


            entity.HasOne(e => e.Order)
            .WithMany(e => e.OrderPastries)
            .HasForeignKey(e => e.OrderID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Pastry)
            .WithMany(e => e.OrderPastries)
            .HasForeignKey(e => e.PastryID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasData(new List<OrderPastry>()
            {
                new OrderPastry
                {
                    OrderID = 1,
                    PastryID = 1,
                    Amount = 3,
                    Comme = "comme-text"
                },
                new OrderPastry
                {
                    OrderID = 2,
                    PastryID = 2,
                    Amount = 2,
                    Comme = "comme-text2"
                },
                new OrderPastry
                {
                    OrderID = 3,
                    PastryID = 3,
                    Amount = 1,
                    Comme = "comme-text3"
                },
            });
        }
    }
}
