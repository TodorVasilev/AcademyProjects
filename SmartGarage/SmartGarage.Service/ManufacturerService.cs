using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    public class ManufacturerService : IManufacturerService
    {
        public ManufacturerService(SmartGarageContext context)
        {
            Context = context;
        }

        public SmartGarageContext Context { get; }

        public async Task<ManufacturerDTO> CreateAsync(ManufacturerDTO manufacturerInformation)
        {
            var manufacturer = new Manufacturer
            {
                Name = manufacturerInformation.Name
            };

            await Context.Manufacturers.AddAsync(manufacturer);
            await Context.SaveChangesAsync();

            return new ManufacturerDTO(manufacturer);
        }
    }
}
