using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGarage.Data.Models;
using System;

namespace SmartGarage.Data.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            var orders = new Order[]
           {
                new Order
                {
                    Id = 1,
                    GarageId = 1,
                    VehicleId = 1,
                    OrderStatusId = 3,
                    ArrivalDate = DateTime.Now.AddDays(-2),
                    FinishDate = DateTime.Now,
                },
                new Order
                {
                    Id = 2,
                    GarageId = 1,
                    VehicleId = 3,
                    OrderStatusId = 1,
                    ArrivalDate = DateTime.Now.AddDays(-3),
                    FinishDate = null,
                },
                    new Order
                {
                    Id = 3,
                    GarageId = 1,
                    VehicleId = 4,
                    OrderStatusId = 2,
                    ArrivalDate = DateTime.Now.AddDays(-10),
                    FinishDate = null,
                },
                    new Order
                {
                    Id = 4,
                    GarageId = 1,
                    VehicleId = 2,
                    OrderStatusId = 2,
                    ArrivalDate = DateTime.Now.AddDays(-4),
                    FinishDate = null,
                },
                    new Order
                {
                    Id = 5,
                    GarageId = 1,
                    VehicleId = 1,
                    OrderStatusId = 1,
                    ArrivalDate = DateTime.Now.AddDays(-1),
                    FinishDate = null,
                },
           };

            builder.HasData(orders);
        }
    }
}
