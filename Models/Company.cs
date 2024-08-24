using System.ComponentModel.DataAnnotations;

namespace jobify_Backend.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string CompanyProfileUrl { get; set; }

        // Foreign key to link the company to the user who owns it
        //public int UserId { get; set; }
        //public User User { get; set; }

        // Navigation property for the jobs posted by this company
        public ICollection<Job> Jobs { get; set; }
        }

    }

