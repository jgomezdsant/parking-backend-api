using Microsoft.EntityFrameworkCore;
using parking_backend_api.Data;
using parking_backend_api.Services.Contract;
using parking_banckend_api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace parking_backend_api.Services.Implementation
{
    public class ServiceVehicle : IServiceVehicle
    {
        private readonly ParkingLotDbContext _dbContext;

        public ServiceVehicle(ParkingLotDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            _dbContext.Vehicles.AddAsync(vehicle);
            await _dbContext.SaveChangesAsync();
            return vehicle;
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            try
            {
                var vehicle = _dbContext.Vehicles.Find(id);
                if (vehicle != null)
                {
                    _dbContext.Vehicles.Remove(vehicle);
                    await _dbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _dbContext.Vehicles.ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _dbContext.Vehicles.Find(id);
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                _dbContext.Entry(vehicle).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
