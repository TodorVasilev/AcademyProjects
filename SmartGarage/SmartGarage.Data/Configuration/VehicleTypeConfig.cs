using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGarage.Data.Models;

namespace SmartGarage.Data.Configuration
{
    public class VehicleTypeConfig : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            var vehicleTypes = new VehicleType[]
            {
                new VehicleType
                {
                    Id = 1,
                    Name = "Car",
                    PriceCoefficient = 1.00
                },

                new VehicleType
                {
                    Id = 2,
                    Name = "Motorcycle",
                    PriceCoefficient = 0.90
                },

                new VehicleType
                {
                    Id = 3,
                    Name = "Bus",
                    PriceCoefficient = 2.0
                },

                new VehicleType
                {
                    Id = 4,
                    Name = "Truck",
                    PriceCoefficient = 2.50
                },
            };

            builder.HasData(vehicleTypes);
        }
    }
}
