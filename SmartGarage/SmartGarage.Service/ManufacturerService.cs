using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Service.Helpers;
using SmartGarage.Data.Models;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Pager<ManufacturerDTO>> GetAllAsync(PaginationQueryObject pagination)
        {
            var skipPages = (pagination.Page - 1) * pagination.ItemsOnPage;

            var manufacturers = Context.Manufacturers;

            if (manufacturers.Count() == 0)
            {
                return null;
            }

            var count = manufacturers.Count();

            var manufacturersDTO = await manufacturers.Skip(skipPages)
                .Take(pagination.ItemsOnPage)
                .Select(x => new ManufacturerDTO(x))
                .ToListAsync();

            Pager<ManufacturerDTO> result = new Pager<ManufacturerDTO>(manufacturersDTO, pagination)
            {
                Count = count
            };

            return result;
        }

        public async Task<ManufacturerDTO> GetAsync(int id)
        {
            var vehicle = await Context.Manufacturers
              .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return null;
            }

            return new ManufacturerDTO(vehicle);
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
