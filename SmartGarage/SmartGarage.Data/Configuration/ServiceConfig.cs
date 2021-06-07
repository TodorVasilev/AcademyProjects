using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGarage.Data.Models;

namespace SmartGarage.Data.Configuration
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            var services = new Service[]
           {
                new Service
                {
                    Id = 1,
                    Name = "Oil change",
                    Price = 74.99M
                },

                new Service
                {
                    Id = 2,
                    Name = "Change all tires",
                    Price = 24.99M
                },

                new Service
                {
                    Id = 3,
                    Name = "Change a tire",
                    Price = 8.99M
                },

                new Service
                {
                    Id = 4,
                    Name = "Pads replacement",
                    Price = 249.99M
                },

                new Service
                {
                    Id = 5,
                    Name = "Battery replacement",
                    Price = 199.99M
                },

                new Service
                {
                    Id = 6,
                    Name = "Computer diagnostic",
                    Price = 35.99M
                },
                new Service
                {
                    Id = 7,
                    Name = "Fuel pump replacment",
                    Price = 180.20M
                },
                new Service
                {
                    Id = 8,
                    Name = "Diagnostic and endgine inspection",
                    Price = 125.30M
                },
           };

            builder.HasData(services);
        }
    }
}
