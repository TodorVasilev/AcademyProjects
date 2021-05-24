using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartGarage.Service.DTOs.GetDTOs
{
    public class GetOrderDTO
    {
        public GetOrderDTO(Order order)
        {
            this.Id = order.Id;
            this.GarageId = order.GarageId;
            this.OrderStatusId = order.OrderStatusId;
            this.VehicleId = order.VehicleId;
            this.ArrivalDate = order.ArrivalDate;
            this.FinishDate = order.FinishDate;
        }
        public int Id { get; set; }

        public int GarageId { get; set; }      
 
        public int OrderStatusId { get; set; }  
      
        public int VehicleId { get; set; }      
    
        public DateTime ArrivalDate { get; set; }

        public DateTime? FinishDate { get; set; }     
    }
}
