using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PastryShopOrders.Models;

namespace PastryShopOrders.Configurations
{
    public class PastryConfiguration : IEntityTypeConfiguration<Pastry>
    {
        public void Configure(EntityTypeBuilder<Pastry> entity)
        {
            entity.ToTable("Pastry");
            entity.HasKey(e => e.ID);

            entity.Property(e => e.Name).HasMaxLength(150).IsRequired();
            entity.Property(e => e.Price).IsRequired();
            entity.Property(e => e.Type).HasMaxLength(40).IsRequired();

            entity.HasData(new List<Pastry>()
            {
                new Pastry
                {
                    ID = 1,
                    Name = "Ciasto czekoladowe",
                    Price = 23.40,
                    Type = "Czekoladowe"
                },
                new Pastry
                {
                    ID = 2,
                    Name = "Ciasto truskawkowo-śmietankowe",
                    Price = 27.90,
                    Type = "Owocowe"
                },
                new Pastry
                {
                    ID = 3,
                    Name = "Ciasto czekoladowo-karmelowe",
                    Price = 34.50,
                    Type = "Czekoladowe"
                }
            });
        }
    }
}
