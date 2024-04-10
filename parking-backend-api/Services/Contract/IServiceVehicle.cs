using parking_banckend_api.Models;

namespace parking_backend_api.Services.Contract
{
    public interface IServiceVehicle
    {
        IEnumerable<Vehicle> GetAllVehicles();

        Vehicle GetVehicleById(int id);

        Task<Vehicle> CreateVehicle(Vehicle vehicle);

        Task<bool> UpdateVehicle(Vehicle vehicle);

        Task<bool> DeleteVehicle(int id);
    }
}
