using SmartGarage.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IVehicleTypeService
    {
        Task<List<VehicleType>> GetAll();
    }
}
