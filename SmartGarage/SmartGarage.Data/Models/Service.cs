using SmartGarage.Data.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarage.Data.Models
{
    public class Service : IIsDeletable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(19,2)")]
        public decimal Price { get; set; }

        public List<ServiceOrder> ServiceOrder { get; set; } = new List<ServiceOrder>();

        public bool IsDeleted { get; set; }
    }
}