using jobify_Backend.Data;
using jobify_Backend.Interfaces;
using jobify_Backend.Models;

namespace jobify_Backend.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool CreateJob(int companyId, Job job)
        {
         
            var company = _context.Companies.Where(c => c.CompanyId == companyId).FirstOrDefault();
            
            if (company == null) return false;

            var jobOfCompany = new CompanyJob
            {
                Job = job,
                Company = company
            };

            _context.Add(jobOfCompany);

            _context.Add(job);
            return Save();
        }

        public bool DeleteJob(Job job)
        {
           _context.Remove(job);
            return Save();
        }

        public Job GetJob(int id)
        {
            return _context.Jobs.Where(j => j.JobId == id).FirstOrDefault();
        }

        public ICollection<Job> GetJobs()
        {
            return _context.Jobs.OrderBy(x => x.JobId).ToList();
        }

        public bool JobExists(int JobId)
        {
            return _context.Jobs.Any(j => j.JobId == JobId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateJob(Job job)
        {
           _context.Update(job);
            return Save();
        }
    }
}
