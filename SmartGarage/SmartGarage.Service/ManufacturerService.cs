using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.Shared;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    /// <summary>
    /// This class is responsible for CRUD operations performed on the manufacturers.
    /// </summary>
    public class ManufacturerService : IManufacturerService
    {
        private readonly SmartGarageContext context;

        public ManufacturerService(SmartGarageContext context)
        {
            this.context = context;
        }

        //Creates new manufacturer
        public async Task<GetManufacturerDTO> CreateAsync(ManufacturerDTO manufacturerInformation)
        {
            var manufacturer = new Manufacturer
            {
                Name = manufacturerInformation.Name
            };

            await context.Manufacturers.AddAsync(manufacturer);
            await context.SaveChangesAsync();

            return new GetManufacturerDTO(manufacturer);
        }

        //Gets all manufacturers based on some specified pagination information.
        public async Task<List<GetManufacturerDTO>> GetAll()
        {
            var manufacturers = context.Manufacturers
                .AsQueryable();

            return await manufacturers.Select(m => new GetManufacturerDTO(m))
                .ToListAsync();
        }

        //Gets manufacturer with specific id.
        public async Task<GetManufacturerDTO> GetAsync(int id)
        {
            var manufacturer = await context.Manufacturers
              .Include(m => m.Models)
              .FirstOrDefaultAsync(v => v.Id == id);

            //Returns null when there is not a manufacturer with this id.
            if (manufacturer == null)
            {
                return null;
            }

            return new GetManufacturerDTO(manufacturer);
        }

        //Updates manufacturer with specific id.
        public async Task<bool> UpdateAsync(ManufacturerDTO updateInformation, int id)
        {
            var manufacturer = await context.Manufacturers
             .FirstOrDefaultAsync(v => v.Id == id);

            //Returns null when there is not a manufacturer with this id.
            if (manufacturer == null)
            {
                return false;
            }

            manufacturer.Name = updateInformation.Name;

            context.Update(manufacturer);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
