namespace jobify_Backend.Dto.JobDtos
{
    public class GetJobDto
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobType { get; set; }
        public string JobDescription { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
    }
}
