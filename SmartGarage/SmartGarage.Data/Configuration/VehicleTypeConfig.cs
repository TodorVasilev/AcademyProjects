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
                    Name = "Car"
                },

                new VehicleType
                {
                    Id = 2,
                    Name = "Motorcycle"
                },

                new VehicleType
                {
                    Id = 3,
                    Name = "Bus"
                },

                new VehicleType
                {
                    Id = 4,
                    Name = "Truck"
                },
            };

            builder.HasData(vehicleTypes);
        }
    }
}
