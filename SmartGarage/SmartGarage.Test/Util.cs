using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;

namespace SmartGarage.Test
{
    public static class Util
    {
        public static DbContextOptions<SmartGarageContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<SmartGarageContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        public static void SeedData(this SmartGarageContext context)
        {
            var users = new List<User>
            {
               new User
               {
                   Id = 1,
                   FirstName = "Admin",
                   LastName = "Admin",
                   UserName = "AdminAdmin",
                   NormalizedUserName = "ADMINADMIN",
                   Address = "Sofia, Bulgaria",
                   Age = 37,
                   Email = "admin@gmail.com",
                   NormalizedEmail = "ADMIN@GMAIL.COM",
                   DrivingLicenseNumber = "93302193",
                    CurrentRole="ADMIN",
                   SecurityStamp = Guid.NewGuid().ToString(),
               },

               new User
               {
                   Id = 2,
                   FirstName = "Emlpoyee",
                   LastName = "Emlpoyee",
                   UserName = "EmlpoyeeEmlpoyee",
                   NormalizedUserName = "EMPLOYEE",
                   Address = "Sofia, Bulgaria",
                   Age = 28,
                   Email = "employee@gmail.com",
                   NormalizedEmail = "EMPLOYEE@GMAIL.COM",
                   DrivingLicenseNumber = "3241219",  
                   CurrentRole="EMPLOYEE",
                   SecurityStamp = Guid.NewGuid().ToString(),
               },

                new User
                {
                    Id = 3,
                    FirstName = "First",
                    LastName = "Customer",
                    UserName = "TheVeryFirstCustomer",
                    NormalizedUserName = "THEVERYFIRSTCUSTOMER",
                    Address = "Sofia, Bulgaria",
                    Age = 28,
                    Email = "firstcustomer@gmail.com",
                    NormalizedEmail = "FIRSTCUSTOMER@GMAIL.COM",
                     DrivingLicenseNumber = "13302343",
                     CurrentRole="CUSTOMER",
                     PhoneNumber="087123456",
                    SecurityStamp = Guid.NewGuid().ToString(),
                },

                new User
                {
                    Id = 4,
                    FirstName = "Ivan",
                    LastName = "Georgiev",
                    UserName = "IvanG",
                    NormalizedUserName = "IVANG",
                    Address = "Burgas, Bulgaria",
                    Age = 40,
                    Email = "ivangeorgiev14@gmail.com",
                    NormalizedEmail = "IVANGEORGIEV14@GMAIL.COM",
                    DrivingLicenseNumber = "73322193",
                      CurrentRole="CUSTOMER",
                    SecurityStamp = Guid.NewGuid().ToString(),
                },

                new User
                {
                    Id = 5,
                    FirstName = "Todor",
                    LastName = "Kolev",
                    UserName = "LoveToAct",
                    NormalizedUserName = "LOVETOACT",
                    Address = "Blagoevgrad, Bulgaria",
                    Age = 22,
                    Email = "californication@gmail.com",
                    NormalizedEmail = "CALIFORNICATION@GMAIL.COM",
                    DrivingLicenseNumber = "91304433",
                      CurrentRole="CUSTOMER",
                    SecurityStamp = Guid.NewGuid().ToString(),
                }
            };

            context.AddRange(users);

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

            context.AddRange(roles);

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
                }
            };

            context.AddRange(userRoles);

            var garage = new Garage
            {
                Id = 1,
                Name = "Insomnia",
                Address = "bil.Graf Ignatiev 0"
            };

            context.AddRange(garage);

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

            context.AddRange(manufacturers);

            var orderStatuses = new OrderStatus[]
            {
                new OrderStatus
                {
                    Id = 1,
                    Name = "Not started"
                },

                new OrderStatus
                {
                    Id = 2,
                    Name = "In progress"
                },

                new OrderStatus
                {
                    Id = 3,
                    Name = "Ready for pickup"
                }
            };

            context.AddRange(orderStatuses);

            var services = new Data.Models.Service[]
            {
                new Data.Models.Service
                {
                    Id = 1,
                    Name = "Oil change",
                    Price = 74.99
                },

                new Data.Models.Service
                {
                    Id = 2,
                    Name = "Change all tires",
                    Price = 24.99
                },

                new Data.Models.Service
                {
                    Id = 3,
                    Name = "Change a tire",
                    Price = 8.99
                },

                new Data.Models.Service
                {
                    Id = 4,
                    Name = "Pads replacement",
                    Price = 249.99
                },

                new Data.Models.Service
                {
                    Id = 5,
                    Name = "Battery replacement",
                    Price = 199.99
                },

                new Data.Models.Service
                {
                    Id = 6,
                    Name = "Computer diagnostic",
                    Price = 35.99
                },
            };

            context.AddRange(services);

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

            context.AddRange(vehicleModels);

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

            context.AddRange(vehicleTypes);

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

            context.AddRange(vehicles);

            var orders = new Order[]
            {
                new Order
                {
                    Id = 1,
                    GarageId = 1,
                    VehicleId = 1,
                    OrderStatusId = 2,
                    ArrivalDate = DateTime.Now.AddDays(1),
                    FinishDate = DateTime.Now.AddDays(3),
                },
                new Order
                {
                    Id = 2,
                    GarageId = 1,
                    VehicleId = 3,
                    OrderStatusId = 1,
                    ArrivalDate = DateTime.Now.AddDays(2),
                    FinishDate = DateTime.Now.AddDays(5),
                },
            };

            context.AddRange(orders);

            var serviceOrders = new ServiceOrder[]
            {
                new ServiceOrder
                {
                    ServiceId = 1,
                    OrderId = 1
                },

                new ServiceOrder
                {
                    ServiceId = 2,
                    OrderId = 2
                }
            };

            context.AddRange(serviceOrders);
        }
    }
}