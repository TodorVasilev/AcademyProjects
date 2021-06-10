using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Data.Models
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public List<VehicleModel> VehicleModels { get; set; } = new List<VehicleModel>();
    }
}