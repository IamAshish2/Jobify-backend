using System.ComponentModel.DataAnnotations;

namespace jobify_Backend.Models
{
    public class JobApplication
    {

        // Foreign key to link the application to the user who applied
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign key to link the application to the job
        public int JobId { get; set; }
        public Job Job { get; set; }
        public string Status { get; set; }
    }

}
