using Microsoft.CodeAnalysis.Scripting;
using WoodWorkshop.DTOs.UserDTOs;
using WoodWorkshop.Models;
using WoodWorkshop.Repositories;


namespace WoodWorkshop.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IInformationUserRepository _infoRepo;

        public UserService(IUserRepository userRepo, IInformationUserRepository infoRepo)
        {
            _userRepo = userRepo;
            _infoRepo = infoRepo;
        }

        public async Task<bool> CreateUserAsync(CreateUserRequest request)
        {
            // Bước 1: Tạo đối tượng InformationUser
            var info = new InformationUser
            {
                PhoneNumber = request.Phone,
                Fullname = request.Fullname,
                Address = request.Address,
                HasAccount = 1,
                Bank = null,
                BankAccountNumber = null,
                CityProvince = null,
                District = null,
                Wards = null
            };

            // Lưu vào DB để lấy infor_id
            var createdInfo = await _infoRepo.AddInformationUserAsync(info);

            if (createdInfo == null || createdInfo.InforId <= 0)
                throw new Exception("Không thể tạo thông tin người dùng");

          
            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                InforId = createdInfo.InforId,
                HireDate = DateOnly.FromDateTime(DateTime.Now),
                RoleId = 2,         // Gán role mặc định
                StatusId = 1,       // Gán trạng thái mặc định (Active)
                PositionId = null   // Có thể gán nếu request có
            };

            await _userRepo.AddUserAsync(user);
            return true;
        }

    }
}
