using jobify_Backend.Data;
using jobify_Backend.Interfaces;
using jobify_Backend.Models;

namespace jobify_Backend.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool CompanyExists(int companyId)
        {
            return _context.Companies.Where(c => c.CompanyId == companyId).Any();  
        }

        public bool CreateCompany(Company company)
        {
            _context.Add(company);
            return Save();
        }

        public bool DeleteCompany(Company company)
        {
            _context.Remove(company);
            return Save();
        }

        public ICollection<Company> GetCompanies()
        {
            return _context.Companies.OrderBy(c => c.CompanyId).ToList();
        }

        public Company GetCompany(int id)
        {
            return _context.Companies.Where(c => c.CompanyId == id).FirstOrDefault();
        }

        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateCompany(Company company)
        {
            _context.Update(company);
            return Save();
        }
    }
}
