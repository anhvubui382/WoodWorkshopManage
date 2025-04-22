using AutoMapper;
using WoodWorkshop.DTOs.UserDTOs;
using WoodWorkshop.Repositories;

namespace WoodWorkshop.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<UserJobsDTO?> GetJobsByUserIdAsync(int userId)
        {
            var user = await _jobRepository.GetUserWithJobsAsync(userId);

            return user == null ? null : _mapper.Map<UserJobsDTO>(user);
        }
    }
}
