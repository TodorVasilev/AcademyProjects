using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

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
            this.ArrivalDate = order.ArrivalDate.Date;
            this.FinishDate = order.FinishDate.Value;
            this.ServicesDTO = order.ServiceOrder.Where(o => o.OrderId == order.Id).Select(o => new GetServiceDTO(o.Service)).ToList();

        }
        public int Id { get; set; }

        public int GarageId { get; set; }

        public int OrderStatusId { get; set; }

        public int VehicleId { get; set; }     

        public DateTime ArrivalDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public List<GetServiceDTO> ServicesDTO { get; set; }
    }
}
