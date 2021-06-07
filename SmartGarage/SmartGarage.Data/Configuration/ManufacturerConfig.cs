using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGarage.Data.Models;

namespace SmartGarage.Data.Configuration
{
    public class ManufacturerConfig : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            var manufacturers = new Manufacturer[]
             {
                new Manufacturer
                {
                    Id = 1,
                    Name = "Tesla"
                },

                new Manufacturer
                {
                    Id = 2,
                    Name = "Toyota"
                },

                new Manufacturer
                {
                    Id = 3,
                    Name = "Volkswagen"
                },

                new Manufacturer
                {
                    Id = 4,
                    Name = "Daimler"
                },

                new Manufacturer
                {
                   Id = 5,
                   Name = "BMW"
                },

                new Manufacturer
                {
                   Id = 6,
                   Name = "Honda"
                },
             };

            builder.HasData(manufacturers);
        }
    }
}
