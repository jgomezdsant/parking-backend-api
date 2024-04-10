using Microsoft.EntityFrameworkCore;
using parking_backend_api.Data;
using parking_backend_api.Services.Contract;
using parking_banckend_api.Models;

namespace parking_backend_api.Services.Implementation
{

    public class ServiceCompany : IServiceCompany
    {
        private readonly ParkingLotDbContext _dbContext;

        public ServiceCompany(ParkingLotDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _dbContext.Companies.ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _dbContext.Companies.Find(id);
        }

        public async Task<Company> CreateCompany(Company company)
        {
            _dbContext.Companies.AddAsync(company);
            await _dbContext.SaveChangesAsync();
            return company;
            
        }

        public async Task<bool> UpdateCompany(Company company)
        {
            try
            {
                _dbContext.Entry(company).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> DeleteCompany(int id)
        {
            try
            {
                var company = _dbContext.Companies.Find(id);
                if (company != null)
                {
                    _dbContext.Companies.Remove(company);
                   await _dbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
