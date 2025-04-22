using Microsoft.EntityFrameworkCore;
using WoodWorkshop.Models;

namespace WoodWorkshop.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly WoodworkshopContext _context;

        public JobRepository(WoodworkshopContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserWithJobsAsync(int userId)
        {
            return await _context.Users
                .Include(u => u.Jobs)
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}
