using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PastryShopOrders.Models;

namespace PastryShopOrders.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.ToTable("Employee");
            entity.HasKey(e => e.ID);

            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();

            entity.HasData(new List<Employee>()
            {
                new Employee
                {
                    ID = 1,
                    FirstName = "Michał",
                    LastName = "Rataj"
                },
                new Employee
                {
                    ID = 2,
                    FirstName = "Oliwia",
                    LastName = "Kozioł"
                },
                new Employee
                {
                    ID = 3,
                    FirstName = "Ewa",
                    LastName = "Wróbel"
                }
            });
        }
    }
}
