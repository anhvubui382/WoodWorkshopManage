using WoodWorkshop.DTOs.JobDTOs;

namespace WoodWorkshop.DTOs.UserDTOs
{
    public class UserJobsDTO
    {
        public int UserId { get; set; }
        public string? Username { get; set; }

        public List<JobDTO> Jobs { get; set; } = new();
    }
}
    