using WoodWorkshop.Models;

namespace WoodWorkshop.Repositories
{
    public interface IInformationUserRepository
    {
        Task<InformationUser> AddInformationUserAsync(InformationUser infoUser);
    }
}
