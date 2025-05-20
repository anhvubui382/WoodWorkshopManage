using WoodWorkshop.DTOs.UserDTOs;
using WoodWorkshop.Models;

namespace WoodWorkshop.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserRequest request);
    }
}
