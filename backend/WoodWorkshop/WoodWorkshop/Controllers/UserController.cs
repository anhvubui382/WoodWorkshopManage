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
       // private readonly IJobService _jobService;
       
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _userService.CreateUserAsync(request);

                if (result)
                    return Ok(new { message = "Tạo người dùng thành công" });  // HTTP 200

                return StatusCode(500, new { message = "Không thể tạo người dùng" }); // HTTP 500
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi server",
                    error = ex.Message,
                    innerError = ex.InnerException?.Message,
                    stackTrace = ex.StackTrace
                });
            }


        }

        //[HttpGet("{id}/jobs")]
        //public async Task<IActionResult> GetJobsByUser(int id)
        //{
        //    var result = await _jobService.GetJobsByUserIdAsync(id);
        //    if (result == null)
        //        return NotFound();

        //    return Ok(result);
        //}
    }
}
