using WoodWorkshop.Models;


namespace WoodWorkshop.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
    }
}
