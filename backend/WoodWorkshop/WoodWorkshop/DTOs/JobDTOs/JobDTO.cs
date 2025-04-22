namespace WoodWorkshop.DTOs.JobDTOs
{
    public class JobDTO
    {
        public int JobId { get; set; }
        public string? Description { get; set; }
        public int? ProductId { get; set; }
        public int? StatusId { get; set; }
    }
}
