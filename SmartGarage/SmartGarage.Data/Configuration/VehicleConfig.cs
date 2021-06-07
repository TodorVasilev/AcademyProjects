using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGarage.Data.Models;

namespace SmartGarage.Data.Configuration
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            var vehicles = new Vehicle[]
            {
                new Vehicle
                {
                    Id = 1,
                    Colour = "Blue",
                    NumberPlate = "CA 1994 BC",
                    UserId = 3,
                    VehicleModelId = 2,
                    VIN = "1HGCM82633A004352"
                },

                new Vehicle
                {
                    Id = 2,
                    Colour = "Black",
                    NumberPlate = "CA 2011 OC",
                    UserId = 3,
                    VehicleModelId = 11,
                    VIN = "1HGCM82633A004352"
                },

                new Vehicle
                {
                    Id = 3,
                    Colour = "Red",
                    NumberPlate = "E 3994 AC",
                    UserId = 4,
                    VehicleModelId = 8,
                    VIN = "1HGCM82633A004352"
                },

                new Vehicle
                {
                    Id = 4,
                    Colour = "White",
                    NumberPlate = "A 1839 BA",
                    UserId = 5,
                    VehicleModelId = 4,
                    VIN = "1HGCM82633A004352"
                }
            };

            builder.HasData(vehicles);
        }
    }
}
