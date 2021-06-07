using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Data.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string Name { get; set; }

        public List<VehicleModel> Models { get; set; } = new List<VehicleModel>();
    }
}