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


            // Foreign key to link the job to the company that posted it
            public int CompanyId { get; set; }
            public Company Company { get; set; }

            // Navigation property for the applications received for this job
            public ICollection<JobApplication> JobApplications { get; set; }
        }

    }

