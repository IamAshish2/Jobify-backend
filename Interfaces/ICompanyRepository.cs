using jobify_Backend.Models;

namespace jobify_Backend.Interfaces
{
    public interface ICompanyRepository
    {
        ICollection<Company> GetCompanies();
        Company GetCompany(int id);
        bool CreateCompany(Company company);
        bool UpdateCompany(Company company);
        bool DeleteCompany(Company company);
        bool Save();
        bool CompanyExists(int companyId);

    }
}
