namespace jobify_Backend.Dto
{
    public class GetUserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
    }
}
