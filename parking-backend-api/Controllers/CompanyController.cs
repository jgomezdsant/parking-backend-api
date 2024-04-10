using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using parking_backend_api.Services.Contract;
using parking_backend_api.Services.Implementation;
using parking_banckend_api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace parking_backend_api.Controllers
{

    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly IServiceCompany _serviceCompany;

        public CompanyController(IServiceCompany companyService)
        {
            _serviceCompany = companyService;
        }

        [HttpGet]
        public IEnumerable<Company> GetAllCompanies()
        {
            return _serviceCompany.GetAllCompanies();
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            var company = _serviceCompany.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public IActionResult CreateCompany([FromBody] Company company)
        {
            _serviceCompany.CreateCompany(company);
            return CreatedAtAction(nameof(GetCompanyById), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }
            await _serviceCompany.UpdateCompany(company);
            return GetCompanyById( company.Id);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = _serviceCompany.GetCompanyById(id);

            await _serviceCompany.DeleteCompany(id);
            return Ok(company);
        }
    }

}
