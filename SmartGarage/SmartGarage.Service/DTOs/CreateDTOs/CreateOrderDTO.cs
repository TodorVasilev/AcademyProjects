using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Service.DTOs.CreateDTOs
{
	public class CreateOrderDTO

	{
		[Required]
		[MinLength(2), MaxLength(20)]
		[Display(Name = "Garage name")]
		public string GarageName { get; set; }

		[Required]
		[MinLength(2), MaxLength(20)]
		[Display(Name = "User name")]
		public string UserName { get; set; }

		[Required]
		[MinLength(2), MaxLength(20)]
		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Required]
		[MinLength(2), MaxLength(20)]
		[Display(Name = "Family name")]
		public string LastName { get; set; }

		[Required]
		[StringLength(10)]
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Phone number")]
		public string PhoneNumber { get; set; }

		[Required]
		[Range(18, 100)]
		[Display(Name = "Age")]
		public int Age { get; set; }

		[Required]
		[Display(Name = "Driving license number")]
		public string DrivingLicenseNumber { get; set; }

		[Required]
		[Display(Name = "Address")]
		public string Address { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = "E-mail")]
		public string Email { get; set; }

		[Required]
		[StringLength(10, MinimumLength = 8, ErrorMessage = "{0} must be between {1} and {2} symbols.")]
		public string NumberPlate { get; set; }

		[Required]
		[StringLength(17, MinimumLength = 17, ErrorMessage = "{0} must be exactly {1} symbols.")]
		public string VIN { get; set; }

		[Required]
		public string Colour { get; set; }

		[Required]
		public int VehicleModelId { get; set; }

	}
}
