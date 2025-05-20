using WoodWorkshop.Models;


namespace WoodWorkshop.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        Task<User> AddUserAsync(User user);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User> GetUserByIdAsync(int userId);
    }
}
