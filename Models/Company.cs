using System.ComponentModel.DataAnnotations;

namespace jobify_Backend.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ContactEmail{ get; set; }
        public string ContactPhone{ get; set; }

        // Navigation property for the jobs posted by this company
        public ICollection<CompanyJob> CompanyJobs { get; set; }
    }

}

