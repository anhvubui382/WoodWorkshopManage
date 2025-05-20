using Microsoft.EntityFrameworkCore;
using WoodWorkshop.Models;

namespace WoodWorkshop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WoodWorkshopContext _context;


        public UserRepository(WoodWorkshopContext context)
        {
            _context = context;
        }
        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
