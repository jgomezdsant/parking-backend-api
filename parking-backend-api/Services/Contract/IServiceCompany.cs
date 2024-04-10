using Microsoft.AspNetCore.Mvc;
using parking_banckend_api.Models;

namespace parking_backend_api.Services.Contract
{
    public interface IServiceCompany
    {
        IEnumerable<Company> GetAllCompanies();

        Company GetCompanyById(int id);

        Task<Company> CreateCompany(Company company);

        Task<bool> UpdateCompany(Company company);

        Task<bool>  DeleteCompany(int id);

    }
}
