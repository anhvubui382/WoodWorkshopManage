using WoodWorkshop.Models;

namespace WoodWorkshop.Repositories
{
    public class InformationUserRepository : IInformationUserRepository
    {
        private readonly WoodWorkshopContext _context;

        public InformationUserRepository(WoodWorkshopContext context)
        {
            _context = context;
        }

        public async Task<InformationUser> AddInformationUserAsync(InformationUser infoUser)
        {
            _context.InformationUsers.Add(infoUser);
            await _context.SaveChangesAsync();
            return infoUser;
        }
    }
}
