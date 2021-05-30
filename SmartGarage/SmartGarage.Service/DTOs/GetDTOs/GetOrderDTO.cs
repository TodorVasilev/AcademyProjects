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
            this.CustomerEmail = order.Vehicle.User.Email;
            this.GarageId = order.GarageId;
            this.Garage = order.Garage.Name;
            this.OrderStatusId = order.OrderStatusId;
            this.OrderStatus = order.OrderStatus.Name;
            this.VehicleId = order.VehicleId;
            this.VehicleNumberPlate = order.Vehicle.NumberPlate;
            this.ArrivalDate = order.ArrivalDate.Date.ToShortDateString();
            this.FinishDate = order.FinishDate.Value.ToShortDateString();
            this.ServicesDTO = order.ServiceOrder.Where(o => o.OrderId == order.Id).Select(o => new GetServiceDTO(o.Service)).ToList();

        }
        public int Id { get; set; }
        public string CustomerEmail { get; set; }

        public int GarageId { get; set; }
        public string Garage { get; set; }

        public int OrderStatusId { get; set; }
        public string OrderStatus { get; set; }

        public int VehicleId { get; set; }     
        public string VehicleNumberPlate { get; set; }

        public string ArrivalDate { get; set; }

        public string FinishDate { get; set; }

        public List<GetServiceDTO> ServicesDTO { get; set; }








      


      
    }
}
