using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGarage.Data.Models;

namespace SmartGarage.Data.Configuration
{
    public class VehicleModelConfig : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            var vehicleModels = new VehicleModel[]
            {
                new VehicleModel
                {
                    Id = 1,
                    Name = "Model X",
                    ManufacturerId = 1,
                    VehicleTypeId = 1
                },

                new VehicleModel
                {
                    Id = 2,
                    Name = "Model S",
                    ManufacturerId = 1,
                    VehicleTypeId = 1
                },

                new VehicleModel
                {
                    Id = 3,
                    Name = "Prius",
                    ManufacturerId = 2,
                    VehicleTypeId = 1
                },

                new VehicleModel
                {
                    Id = 4,
                    Name = "HiAce H300",
                    ManufacturerId = 2,
                    VehicleTypeId = 3
                },

                new VehicleModel
                {
                    Id = 5,
                    Name = "Passat",
                    ManufacturerId = 3,
                    VehicleTypeId = 1
                },

                new VehicleModel
                {
                    Id = 6,
                    Name = "Arteon",
                    ManufacturerId = 3,
                    VehicleTypeId = 1
                },

                new VehicleModel
                {
                    Id = 7,
                    Name = "C-class",
                    ManufacturerId = 4,
                    VehicleTypeId = 1
                },

                new VehicleModel
                {
                    Id = 8,
                    Name = "Western-Star",
                    ManufacturerId = 4,
                    VehicleTypeId = 4
                },

                new VehicleModel
                {
                    Id = 9,
                    Name = "X6",
                    ManufacturerId = 5,
                    VehicleTypeId = 1
                },

                new VehicleModel
                {
                    Id = 10,
                    Name = "E30",
                    ManufacturerId = 5,
                    VehicleTypeId = 1
                },

                new VehicleModel
                {
                    Id = 11,
                    Name = "Hornet",
                    ManufacturerId = 6,
                    VehicleTypeId = 2
                },

                new VehicleModel
                {
                    Id = 12,
                    Name = "Civic",
                    ManufacturerId = 6,
                    VehicleTypeId = 1
                },
            };

            builder.HasData(vehicleModels);
        }
    }
}
