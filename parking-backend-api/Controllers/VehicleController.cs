using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using parking_backend_api.Services.Contract;
using parking_backend_api.Services.Implementation;
using parking_banckend_api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace parking_backend_api.Controllers
{

    [ApiController]
    [Route("api/vehicles")]
    public class VehicleController : ControllerBase
    {
        private readonly IServiceVehicle _serviceVehicle;
        private readonly IServiceCompany _serviceCompany;

        public VehicleController(IServiceVehicle vehicleService, IServiceCompany serviceCompany)
        {
            _serviceVehicle = vehicleService;
            _serviceCompany = serviceCompany;
        }

        [HttpGet]
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _serviceVehicle.GetAllVehicles();
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var company = _serviceVehicle.GetVehicleById(id);

            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }


        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public IActionResult CreateVehicle([FromBody] Vehicle vehicle)
        {
            vehicle.isParking = true;
            var company = _serviceCompany.GetCompanyById(vehicle.CompanyId);
            var totalVehicles = _serviceVehicle.GetAllVehicles();
            var totalType = totalVehicles.Count(x => x.Type == vehicle.Type && x.CompanyId == vehicle.CompanyId && x.isParking == true);

            int availableSpaces = company != null ? (vehicle.Type == 1) ? company.NumberCarSpaces : company.NumberMotorcycleSpaces : 0 ;

            if (totalType > availableSpaces)
            {
                return BadRequest(new { message = "There are no spaces available" });
            }

            _serviceVehicle.CreateVehicle(vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }
            await _serviceVehicle.UpdateVehicle(vehicle);
            return GetVehicleById(vehicle.Id);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var company = _serviceVehicle.GetVehicleById(id);

            await _serviceVehicle.DeleteVehicle(id);
            return Ok(company);
        }
    }

}
