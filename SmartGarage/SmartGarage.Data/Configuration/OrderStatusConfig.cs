using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGarage.Data.Models;

namespace SmartGarage.Data.Configuration
{
    public class OrderStatusConfig : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            var orderStatuses = new OrderStatus[]
            {
                new OrderStatus
                {
                    Id = 1,
                    Name = "Not started"
                },

                new OrderStatus
                {
                    Id = 2,
                    Name = "In progress"
                },

                new OrderStatus
                {
                    Id = 3,
                    Name = "Ready for pickup"
                }
            };

            builder.HasData(orderStatuses);
        }
    }
}
