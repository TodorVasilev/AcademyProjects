using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

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
				.OnDelete(DeleteBehavior.Cascade);

			builder.Entity<ServiceOrder>()
				.HasOne(so => so.Service)
				.WithMany(o => o.ServiceOrder)
				.OnDelete(DeleteBehavior.Cascade);


			var users = new List<User>
			{
			   new User
			   {
				   Id = 1,
				   FirstName = "Smart",
				   LastName = "Garage",
				   UserName = "SmartGarage",
				   NormalizedUserName = "SMARTGARAGE",
				   Address = "Sofia, Bulgaria",
				   Age = 37,
				   Email = "smartgarage@gmail.com",
				   NormalizedEmail = "SMARTGARAGE@GMAIL.COM",
				   DrivingLicenseNumber = "93302193",
				   CurrentRole= "ADMIN",
				   SecurityStamp = Guid.NewGuid().ToString(),
			   },

			   new User
			   {
				   Id = 2,
				   FirstName = "Petar",
				   LastName = "Petrov",
				   UserName = "PetarPetrov",
				   NormalizedUserName = "PETARPETROV",
				   Address = "Sofia, Bulgaria",
				   Age = 28,
				   Email = "petar@test.com",
				   NormalizedEmail = "PETAR@TEST.COM",
				   DrivingLicenseNumber = "3241219",
				   CurrentRole= "EMPLOYEE",
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
					 CurrentRole= "CUSTOMER",
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
					CurrentRole= "CUSTOMER",
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
					CurrentRole= "CUSTOMER",
					SecurityStamp = Guid.NewGuid().ToString(),
				},
				new User
				{
					Id = 6,
					FirstName = "Penka",
					LastName = "Petrova",
					UserName = "PenkaPetrova",
					NormalizedUserName = "PENKAPETROVA",
					Address = "Blagoevgrad, Bulgaria",
					Age = 24,
					Email = "penkapetrova@gmail.com",
					NormalizedEmail = "PENKAPETROVA@GMAIL.COM",
					DrivingLicenseNumber = "91304433123",
					CurrentRole= "CUSTOMER",
					SecurityStamp = Guid.NewGuid().ToString(),
				},
				new User
				{
					Id = 7,
					FirstName = "Ivan",
					LastName = "Dimitrov",
					UserName = "IvanDimitrov",
					NormalizedUserName = "IVANDIMITROV",
					Address = "Botevgrad, Bulgaria",
					Age = 31,
					Email = "ivandimitrov@gmail.com",
					NormalizedEmail = "IVANDIMITROV@GMAIL.COM",
					DrivingLicenseNumber = "4984654156",
					CurrentRole= "CUSTOMER",
					SecurityStamp = Guid.NewGuid().ToString(),
				},
				new User
				{
					Id = 8,
					FirstName = "Marian",
					LastName = "Kuzmov",
					UserName = "MarianKusmov",
					NormalizedUserName = "MARIANKUZMOV",
					Address = "Russe, Bulgaria",
					Age = 48,
					Email = "kuzmov34@gmail.com",
					NormalizedEmail = "KUZMOV34@GMAIL.COM",
					DrivingLicenseNumber = "498124654156",
					CurrentRole= "CUSTOMER",
					SecurityStamp = Guid.NewGuid().ToString(),
				},
				new User
				{
					Id = 9,
					FirstName = "Petar",
					LastName = "Lakov",
					UserName = "PetarLakov",
					NormalizedUserName = "PETARLAKOV",
					Address = "Sofia, Bulgaria",
					Age = 35,
					Email = "pepilakov34@gmail.com",
					NormalizedEmail = "PEPILAKOV34@GMAIL.COM",
					DrivingLicenseNumber = "49812324654156",
					CurrentRole= "CUSTOMER",
					SecurityStamp = Guid.NewGuid().ToString(),
				},
				new User
				{
					Id = 10,
					FirstName = "Nikola",
					LastName = "Urumov",
					UserName = "NikolaUrumov",
					NormalizedUserName = "NIKOLAURUMOV",
					Address = "Dobrich, Bulgaria",
					Age = 24,
					Email = "nikola12@gmail.com",
					NormalizedEmail = "NIKOLA12@GMAIL.COM",
					DrivingLicenseNumber = "4982124654156",
					CurrentRole= "CUSTOMER",
					SecurityStamp = Guid.NewGuid().ToString(),
				},
				new User
				{
					Id = 11,
					FirstName = "Roman",
					LastName = "Abramovich",
					UserName = "Rumi123",
					NormalizedUserName = "RUMI123",
					Address = "Pernik, Bulgaria",
					Age = 49,
					Email = "rumi@gmail.com",
					NormalizedEmail = "RUMI@GMAIL.COM",
					DrivingLicenseNumber = "42134654156",
					CurrentRole= "CUSTOMER",
					SecurityStamp = Guid.NewGuid().ToString(),
				}

			};

			var passHasher = new PasswordHasher<User>();

			users[0].PasswordHash = passHasher.HashPassword(users[0], "SmartGarage123");
			users[1].PasswordHash = passHasher.HashPassword(users[1], "Petar123");
			users[2].PasswordHash = passHasher.HashPassword(users[2], "Customer123");
			users[3].PasswordHash = passHasher.HashPassword(users[3], "Ivan123");
			users[4].PasswordHash = passHasher.HashPassword(users[4], "Todor123");
			users[5].PasswordHash = passHasher.HashPassword(users[5], "Petar123");
			users[6].PasswordHash = passHasher.HashPassword(users[6], "Nikola123");
			users[7].PasswordHash = passHasher.HashPassword(users[7], "Dragan123");
			users[8].PasswordHash = passHasher.HashPassword(users[8], "Petkan123");
			users[9].PasswordHash = passHasher.HashPassword(users[9], "Gogo123");
			users[10].PasswordHash = passHasher.HashPassword(users[10], "Dummy123");

			builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
			builder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
			builder.Entity<User>().HasData(users);

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

			builder.Entity<Role>().HasData(roles);

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

			builder.Entity<IdentityUserRole<int>>().HasData(userRoles);

			var garage = new Garage
			{
				Id = 1,
				Name = "Insomnia",
				Address = "bul.Graf Ignatiev 0"
			};

			builder.Entity<Garage>().HasData(garage);

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

			builder.Entity<Manufacturer>().HasData(manufacturers);

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

			builder.Entity<OrderStatus>().HasData(orderStatuses);

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

			builder.Entity<Service>().HasData(services);

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

			builder.Entity<VehicleModel>().HasData(vehicleModels);

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

			builder.Entity<VehicleType>().HasData(vehicleTypes);

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

			builder.Entity<Vehicle>().HasData(vehicles);


			var orders = new Order[]
			{
				new Order
				{
					Id = 1,
					GarageId = 1,
					VehicleId = 1,
					OrderStatusId = 3,
					ArrivalDate = DateTime.Now.AddDays(-2),
					FinishDate = DateTime.Now,
				},
				new Order
				{
					Id = 2,
					GarageId = 1,
					VehicleId = 3,
					OrderStatusId = 1,
					ArrivalDate = DateTime.Now.AddDays(-3),
					FinishDate = null,
				},
					new Order
				{
					Id = 3,
					GarageId = 1,
					VehicleId = 4,
					OrderStatusId = 2,
					ArrivalDate = DateTime.Now.AddDays(-10),
					FinishDate = null,
				},
					new Order
				{
					Id = 4,
					GarageId = 1,
					VehicleId = 2,
					OrderStatusId = 2,
					ArrivalDate = DateTime.Now.AddDays(-4),
					FinishDate = null,
				},
					new Order
				{
					Id = 5,
					GarageId = 1,
					VehicleId = 1,
					OrderStatusId = 1,
					ArrivalDate = DateTime.Now.AddDays(-1),
					FinishDate = null,
				},
			};

			builder.Entity<Order>().HasData(orders);

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
				},

				new ServiceOrder
				{
					ServiceId = 1,
					OrderId = 3
				},

				new ServiceOrder
				{
					ServiceId = 5,
					OrderId = 4
				},

				new ServiceOrder
				{
					ServiceId = 3,
					OrderId = 5
				},

				new ServiceOrder
				{
					ServiceId = 3,
					OrderId = 1
				}	
			};

			builder.Entity<ServiceOrder>().HasData(serviceOrders);
		}
	}
}
