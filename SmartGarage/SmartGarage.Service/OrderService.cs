using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using System;
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
        public async Task<bool> UpdateAsync(int id, UpdateOrderDTO updateOrder)
        {
            var orderToUpdate = await context.Orders.FindAsync(id);

            if (orderToUpdate == null || orderToUpdate.IsDeleted == true)
            {
                return false;
            }
            if (updateOrder.GarageId!=0)
            {
                orderToUpdate.GarageId = updateOrder.GarageId;
            }
            if (updateOrder.OrderStatusId!=0)
            {
                orderToUpdate.OrderStatusId = updateOrder.OrderStatusId;
            }
            if (updateOrder.FinishDate.Value>=orderToUpdate.ArrivalDate.Date && updateOrder.FinishDate.Value!=null)
            {
                orderToUpdate.FinishDate = updateOrder.FinishDate;
            }
            if (updateOrder.VehicleId!=0)
            {
                orderToUpdate.VehicleId = updateOrder.VehicleId;
            }
            
           await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddService(List<ServiceOrder> serviceOrder)
        {
            await this.context.ServiceOrders.AddRangeAsync(serviceOrder);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
