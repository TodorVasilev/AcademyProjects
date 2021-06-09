using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;

namespace SmartGarage.Data.Configuration
{
	public class UserConfig : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
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
				   PhoneNumber = "0851547896"
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
				   PhoneNumber = "0851521896"
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
				    PhoneNumber = "0851545496"
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
				    PhoneNumber = "0878647896"
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
					PhoneNumber = "0871247896"
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
					PhoneNumber = "0879737896"
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
					PhoneNumber = "08897247896"
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
					PhoneNumber = "08897247943"
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
					PhoneNumber = "08897247444"
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
					PhoneNumber = "08897247111"
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
					PhoneNumber = "0889724777"
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

			builder.HasIndex(u => u.Email).IsUnique();
			builder.HasIndex(u => u.UserName).IsUnique();
			builder.HasData(users);
		}
	}
}
