using Microsoft.EntityFrameworkCore;
using WoodWorkshop.Models;

namespace WoodWorkshop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WoodWorkshop2025Context _context;

        public UserRepository(WoodWorkshop2025Context context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(user => user.UserId == userId);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
