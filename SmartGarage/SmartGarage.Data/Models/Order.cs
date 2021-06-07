using SmartGarage.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Data.Models
{
    public class Order : IIsDeletable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GarageId { get; set; }
        public Garage Garage { get; set; }

        [Required]
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        [Required]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public bool IsDeleted { get; set; }

        public List<ServiceOrder> ServiceOrder { get; set; } = new List<ServiceOrder>();
    }
}