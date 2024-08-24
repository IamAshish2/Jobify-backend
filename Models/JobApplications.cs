using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace jobify_Backend.Models
{
    public class JobApplication
    {
        [Key]
        public int JobApplicationId{ get; set; }
        // Foreign key to link the application to the user who applied
        public int? UserId { get; set; }
        public User User { get; set; }

        // Foreign key to link the application to the job
        public int? JobId { get; set; }
        public Job Job { get; set; }
        //public string Status { get; set; }
    }

}
