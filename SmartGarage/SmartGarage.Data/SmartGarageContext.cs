using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SmartGarage.Data
{
    public class SmartGarageContext : IdentityDbContext<User, Role, int>
    {
        public SmartGarageContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Garage> Garages { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceOrder> ServiceOrders { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleModel> VehicleModels { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<ServiceOrder>()
                .HasKey(so => new { so.ServiceId, so.OrderId });

            builder.Entity<ServiceOrder>()
                .HasOne(so => so.Order)
                .WithMany(o => o.ServiceOrder)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ServiceOrder>()
                .HasOne(so => so.Service)
                .WithMany(o => o.ServiceOrder)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
