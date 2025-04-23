using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoodWorkshop.DTOs.UserDTOs;
using WoodWorkshop.Models;
using WoodWorkshop.Services;

namespace WoodWorkshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

          
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email
            };

            _userService.CreateUser(user);

            return Ok(new { message = "User created successfully." });
        }

        [HttpGet("{id}/jobs")]
        public async Task<IActionResult> GetJobsByUser(int id)
        {
            var result = await _jobService.GetJobsByUserIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
