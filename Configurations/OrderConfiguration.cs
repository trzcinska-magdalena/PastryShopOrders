using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PastryShopOrders.Models;

namespace PastryShopOrders.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.ToTable("Order");
            entity.HasKey(e => e.ID);

            entity.Property(e => e.AcceptedAt).IsRequired();
            entity.Property(e => e.Comments).HasMaxLength(300);


            entity.HasOne(e => e.Client)
            .WithMany(e => e.Orders)
            .HasForeignKey(e => e.ClientID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Employee)
            .WithMany(e => e.Orders)
            .HasForeignKey(e => e.ClientID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasData(new List<Order>()
            {
                new Order
                {
                    ID = 1,
                    AcceptedAt = new DateTime(2023, 01, 20),
                    FulfilledAt = null,
                    Comments = "text-Comments",
                    ClientID = 1,
                    EmployeeID = 2
                },
                new Order
                {
                    ID = 2,
                    AcceptedAt = new DateTime(2023, 01, 27),
                    FulfilledAt = new DateTime(2023, 02, 02),
                    Comments = null,
                    ClientID = 2,
                    EmployeeID = 2
                },
                new Order
                {
                    ID = 3,
                    AcceptedAt = new DateTime(2023, 02, 20),
                    FulfilledAt = null,
                    Comments = "text-Comments22",
                    ClientID = 3,
                    EmployeeID = 3
                },
            });
        }
    }
}
