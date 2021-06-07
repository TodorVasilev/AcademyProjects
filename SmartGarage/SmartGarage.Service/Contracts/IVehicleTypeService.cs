using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IVehicleTypeService
    {
        Task<List<VehicleType>> GetAll();
    }
}
