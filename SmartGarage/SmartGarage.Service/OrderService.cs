using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    public class OrderService : IOrderService
    {
        private readonly SmartGarageContext context;
        public OrderService(SmartGarageContext context)
        {
            this.context = context;
        }

        public async Task<List<GetOrderDTO>> GetAll()
        {
            var orders = context.Orders.Where(o => !o.IsDeleted)
                .AsQueryable();

            return await orders.Select(order => new GetOrderDTO(order))
                .ToListAsync();
        }
        public async Task<GetOrderDTO> GetAsync(int id)
        {
            var order = await context.Orders.FindAsync(id);
            if (order == null || order.IsDeleted == true)
            {
                return null;
            }
            return new GetOrderDTO(order);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await context.Orders.FindAsync(id);
            if (order == null || order.IsDeleted == true)
            {
                return false;
            }
            order.IsDeleted = true;
            this.context.SaveChanges();
            return true;
        }
    }
}
