using Microsoft.EntityFrameworkCore;
using WoodWorkshop.Models;

namespace WoodWorkshop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WoodworkshopContext _context;

        public UserRepository(WoodworkshopContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
