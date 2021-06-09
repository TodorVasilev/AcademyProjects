using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.ViewModels
{
	public class UpdateUserViewModel
	{
		[Required]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
		[Display(Name = "User name:")]
		public string UserName { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
		[Display(Name = "First name:")]
		public string FirstName { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
		[Display(Name = "Family name:")]
		public string LastName { get; set; }


		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"[0]{1}\d{9}", ErrorMessage = "Invalid phone number")]
		[Display(Name = "Phone number:")]
		public string PhoneNumber { get; set; }

		[Required]
		[Range(18, 100)]
		[Display(Name = "Age:")]
		public int Age { get; set; }

		[Required]
		[Display(Name = "Driving license number:")]
		public string DrivingLicenseNumber { get; set; }

		[Required]
		[Display(Name = "Address:")]
		public string Address { get; set; }

		[EmailAddress]
		[Display(Name = "E-mail:")]
		public string Email { get; set; }
	}
}


