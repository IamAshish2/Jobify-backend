using System.ComponentModel.DataAnnotations;

namespace jobify_Backend.Models
{
    public class Job
    {
        [Key]
            public int JobId { get; set; }
            public string JobTitle { get; set; }
            public string JobType{ get; set; }
            public string JobDescription { get; set; }
            public string Location { get; set; }
            public decimal Salary { get; set; }

            // collection of companies that provide jobs
            public ICollection<CompanyJob> CompanyJobs { get; set; }
            //Collection of job applications for a certain job
            public ICollection<JobApplication> JobApplications { get; set; }
        }

    }

