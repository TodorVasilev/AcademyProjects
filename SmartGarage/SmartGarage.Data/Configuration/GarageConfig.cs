using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGarage.Data.Models;

namespace SmartGarage.Data.Configuration
{
    public class GarageConfig : IEntityTypeConfiguration<Garage>
    {
        public void Configure(EntityTypeBuilder<Garage> builder)
        {
            var garage = new Garage
            {
                Id = 1,
                Name = "Insomnia",
                Address = "bul.Graf Ignatiev 0"
            };

            builder.HasData(garage);
        }
    }
}