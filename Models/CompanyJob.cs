namespace jobify_Backend.Models
{
    public class CompanyJob
    {
        public int? JobId { get; set; }
        public Job Job { get; set; }
        public int? CompanyId {  get; set; }
        public Company Company { get; set; }
    }
}
