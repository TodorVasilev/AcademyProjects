using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGarage.Data.Models;

namespace SmartGarage.Data.Configuration
{
    public class ServiceOrderConfig : IEntityTypeConfiguration<ServiceOrder>
    {
        public void Configure(EntityTypeBuilder<ServiceOrder> builder)
        {
            builder.HasKey(so => new { so.ServiceId, so.OrderId });

            builder.HasOne(so => so.Order)
                .WithMany(o => o.ServiceOrder)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(so => so.Service)
                .WithMany(o => o.ServiceOrder)
                .OnDelete(DeleteBehavior.Cascade);

            var serviceOrders = new ServiceOrder[]
            {
                new ServiceOrder
                {
                    ServiceId = 1,
                    OrderId = 1
                },

                new ServiceOrder
                {
                    ServiceId = 2,
                    OrderId = 2
                },

                new ServiceOrder
                {
                    ServiceId = 1,
                    OrderId = 3
                },

                new ServiceOrder
                {
                    ServiceId = 5,
                    OrderId = 4
                },

                new ServiceOrder
                {
                    ServiceId = 3,
                    OrderId = 5
                },

                new ServiceOrder
                {
                    ServiceId = 3,
                    OrderId = 1
                }
            };

            builder.HasData(serviceOrders);
        }
    }
}
