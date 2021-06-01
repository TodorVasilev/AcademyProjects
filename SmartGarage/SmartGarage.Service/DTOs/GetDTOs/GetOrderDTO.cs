using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;

namespace SmartGarage.Service.DTOs.GetDTOs
{
	public class GetOrderDTO
	{
		public GetOrderDTO(Order order)
		{
			this.Id = order.Id;
			this.CustomerName = order.Vehicle.User.FirstName + " " + order.Vehicle.User.LastName;
			this.Garage = order.Garage.Name;
			this.OrderStatusId = order.OrderStatusId;
			this.OrderStatus = order.OrderStatus.Name;
			this.VehicleId = order.VehicleId;
			this.VehicleNumberPlate = order.Vehicle.NumberPlate;
			this.ArrivalDate = order.ArrivalDate.Date.ToShortDateString();
			if (order.FinishDate != null)
			{
				this.FinishDate = order.FinishDate.Value.ToShortDateString();
			}
			else
			{
				this.FinishDate = "Not finished yet!";
			}

			this.Services = order.ServiceOrder.Where(o => o.OrderId == order.Id).Select(o => new GetServiceDTO(o.Service)).ToList();
			this.TotalPrice = this.Services.Sum(s => s.Price);
		}
		public int Id { get; set; }
		[DisplayName("Customer Name:")]
		public string CustomerName { get; set; }

		public int GarageId { get; set; }

		[DisplayName("Garage:")]
		public string Garage { get; set; }

		public int OrderStatusId { get; set; }

		[DisplayName("Status:")]
		public string OrderStatus { get; set; }

		public int VehicleId { get; set; }

		[DisplayName("Vehicle Number Plate:")]
		public string VehicleNumberPlate { get; set; }

		[DisplayName("Arrival Date:")]
		public string ArrivalDate { get; set; }

		[DisplayName("Finish Date:")]
		public string FinishDate { get; set; }

		[DisplayName("Services:")]
		public List<GetServiceDTO> Services { get; set; }
		[DisplayName("Total Price:")]
		public decimal TotalPrice { get; set; }












	}
}
