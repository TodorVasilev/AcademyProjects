using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartGarage.Data.Configuration
{
    public class UserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            var userRoles = new IdentityUserRole<int>[]
             {
                new IdentityUserRole<int>
                {
                    UserId = 1,
                    RoleId = 1
                },

                new IdentityUserRole<int>
                {
                    UserId = 2,
                    RoleId = 2
                },

                new IdentityUserRole<int>
                {
                    UserId = 3,
                    RoleId = 3
                },
               new IdentityUserRole<int>
                {
                    UserId = 4,
                    RoleId = 3
                },
               new IdentityUserRole<int>
                {
                    UserId = 5,
                    RoleId = 3
                },
               new IdentityUserRole<int>
                {
                    UserId = 6,
                    RoleId = 3
                },
               new IdentityUserRole<int>
                {
                    UserId = 7,
                    RoleId = 3
                },
               new IdentityUserRole<int>
                {
                    UserId = 8,
                    RoleId = 3
                },
               new IdentityUserRole<int>
                {
                    UserId = 9,
                    RoleId = 3
                },
               new IdentityUserRole<int>
                {
                    UserId = 10,
                    RoleId = 3
                },
               new IdentityUserRole<int>
                {
                    UserId = 11,
                    RoleId = 3
                }
             };

            builder.HasData(userRoles);
        }
    }
}
