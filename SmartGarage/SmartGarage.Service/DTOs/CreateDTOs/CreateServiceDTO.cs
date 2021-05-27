using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Service.DTOs.CreateDTOs
{
    public class CreateServiceDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double? Price { get; set; }
    }
}
