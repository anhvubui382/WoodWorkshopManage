using WoodWorkshop.Models;

namespace WoodWorkshop.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);


    }
}
