using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.ViewModels
{
	public class ServiceOrderViewModel
	{
		public List<GetServiceDTO> UsedServices { get; set; }
		public List<GetServiceDTO> AvailableServices { get; set; }

	}
}
