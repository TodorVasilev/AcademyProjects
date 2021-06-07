using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGarage.Data.Models;
using System.Collections.Generic;

namespace SmartGarage.Data.Configuration
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            var roles = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },

                new Role
                {
                    Id = 2,
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },

                 new Role
                 {
                    Id = 3,
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                 }
            };

            builder.HasData(roles);
        }
    }
}
