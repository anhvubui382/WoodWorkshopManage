namespace WoodWorkshop.DTOs.UserDTOs
{
    public class CreateUserRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; } 
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Fullname { get; set; }
        public string? DetailAddress { get; set; }

    }
}
