namespace WoodWorkshop.DTOs.UserDTOs
{
    public class UserJobsDTO
    {
        public int UserId { get; set; }
        public string? Username { get; set; }

        public List<JobDto> Jobs { get; set; } = new();
    }
}
    