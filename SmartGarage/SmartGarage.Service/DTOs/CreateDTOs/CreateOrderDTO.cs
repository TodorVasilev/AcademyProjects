﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartGarage.Service.DTOs.CreateDTOs
{
    public class CreateOrderDTO
    {       
        public int GarageId { get; set; }

        public int OrderStatusId { get; set; }

        public int VehicleId { get; set; }

        public DateTime ArrivalDate { get; set; }
               
    }
}
