using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.Shared;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    /// <summary>
    /// This class is responsible for CRUD operations performed on the manufacturers.
    /// </summary>
    public class ManufacturerService : IManufacturerService
    {
        public ManufacturerService(SmartGarageContext context)
        {
            Context = context;
        }

        public SmartGarageContext Context { get; }

        //Creates new manufacturer
        public async Task<GetManufacturerDTO> CreateAsync(ManufacturerDTO manufacturerInformation)
        {
            var manufacturer = new Manufacturer
            {
                Name = manufacturerInformation.Name
            };

            await Context.Manufacturers.AddAsync(manufacturer);
            await Context.SaveChangesAsync();

            return new GetManufacturerDTO(manufacturer);
        }

        //Gets all manufacturers based on some specified pagination information.
        public async Task<Pager<GetManufacturerDTO>> GetAllAsync(PaginationQueryObject pagination)
        {
            //The amount of items to skip
            var skipPages = (pagination.Page - 1) * pagination.ItemsOnPage;

            var manufacturers = Context.Manufacturers
                .AsQueryable();

            var count = manufacturers.Count();

            var manufacturersDTO = await manufacturers.Skip(skipPages)
                .Take(pagination.ItemsOnPage)
                .Select(x => new GetManufacturerDTO(x))
                .ToListAsync();

            Pager<GetManufacturerDTO> result = new Pager<GetManufacturerDTO>(manufacturersDTO, pagination)
            {
                Count = count
            };

            return result;
        }

        //Gets manufacturer with specific id.
        public async Task<GetManufacturerDTO> GetAsync(int id)
        {
            var manufacturer = await Context.Manufacturers
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
            var manufacturer = await Context.Manufacturers
             .FirstOrDefaultAsync(v => v.Id == id);

            //Returns null when there is not a manufacturer with this id.
            if (manufacturer == null)
            {
                return false;
            }

            manufacturer.Name = updateInformation.Name;

            Context.Update(manufacturer);
            await Context.SaveChangesAsync();

            return true;
        }
    }
}
