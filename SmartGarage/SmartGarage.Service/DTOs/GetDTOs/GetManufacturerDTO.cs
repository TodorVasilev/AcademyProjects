using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartGarage.Service.DTOs.GetDTOs
{
    public class GetManufacturerDTO
    {
        public GetManufacturerDTO(Manufacturer manufacturer)
        {
            this.Id = manufacturer.Id;
            this.Name = manufacturer.Name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}
