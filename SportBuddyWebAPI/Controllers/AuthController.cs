using BusinessLayer.Abstract;
using CoreLayer.Entities.Concerete;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportBuddyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        private IAuthService _authService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(User user)
        {

            var result = _userService.DeleteUser(user);
            if (result.Success)
            {
                return Ok(result.Success);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {

            var result = _userService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user,  string password=null)
        {
    
         
            var result = _userService.UpdateUser(user, password);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {

            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }
            else
            {
                var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Passwd);
                var result = _authService.CreateAccessToken(registerResult.Data);
                if (result.Success)
                {
                    return Ok(201);
                }
                return BadRequest(result.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);

            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }
        [HttpGet("getUserById")]
        public IActionResult GetUserById(int userId)
        {
 
            var result = _userService.GetById(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
         
        }


    }
}

