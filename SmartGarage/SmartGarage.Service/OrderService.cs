using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var orders = context.Orders
                .AsQueryable();

            return await orders.Select(order => new GetOrderDTO(order))
                .ToListAsync();
        }
    }
}
