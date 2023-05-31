using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PastryShopOrders.Models;
using System.Numerics;

namespace PastryShopOrders.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {
            entity.ToTable("Client");
            entity.HasKey(e => e.ID);

            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();

            entity.HasData(new List<Client>()
            {
                new Client
                {
                    ID = 1,
                    FirstName = "Anna",
                    LastName = "Kowalska"
                },
                new Client
                {
                    ID = 2,
                    FirstName = "Karol",
                    LastName = "Suska"
                },
                new Client
                {
                    ID = 3,
                    FirstName = "Anna",
                    LastName = "Sowińska"
                }
            });
        }
    }
}
