using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Service.DTOs.CreateDTOs
{
	public class CreateServiceDTO
	{
		[Required]
		[MinLength(3, ErrorMessage = "Enter minimum 3 chars.")]
		public string Name { get; set; }

		[Required]
		[Range(0,10000, ErrorMessage = "Min price is 0 €")]
		public decimal? Price { get; set; }
	}
}
