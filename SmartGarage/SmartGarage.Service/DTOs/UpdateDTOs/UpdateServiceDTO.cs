using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Service.DTOs.UpdateDTOs
{
    public class UpdateServiceDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }
    }
}
