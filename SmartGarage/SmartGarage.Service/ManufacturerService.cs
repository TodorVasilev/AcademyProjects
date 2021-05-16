using Microsoft.EntityFrameworkCore;
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

        public async Task<ManufacturerDTO> UpdateAsync(ManufacturerDTO updateInformation, int id)
        {
            var manufacturer = await Context.Manufacturers
             .FirstOrDefaultAsync(v => v.Id == id);

            if (manufacturer == null)
            {
                return null;
            }

            manufacturer.Name = updateInformation.Name;

            Context.Update(manufacturer);
            await Context.SaveChangesAsync();

            return new ManufacturerDTO(manufacturer);
        }
    }
}
