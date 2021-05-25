using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Data.Models
{
    public class ServiceOrder
    {
        [Required]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
