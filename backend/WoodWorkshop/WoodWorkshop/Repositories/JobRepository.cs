//using Microsoft.EntityFrameworkCore;
//using WoodWorkshop.Models;

//namespace WoodWorkshop.Repositories
//{
//    public class JobRepository : IJobRepository
//    {
//        private readonly WoodWorkshop2025Context _context;

//        public JobRepository(WoodWorkshop2025Context context)
//        {
//            _context = context;
//        }

//        public async Task<User?> GetUserWithJobsAsync(int userId)
//        {
//            return await _context.Users
//                .Include(u => u.Jobs)
//                .FirstOrDefaultAsync(u => u.UserId == userId);
//        }
//    }
//}
