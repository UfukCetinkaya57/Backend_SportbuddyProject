using BusinessLayer.Abstract;
using CoreLayer.Entities.Concerete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportBuddyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpGet("getProfileById")]
        public IActionResult GetProfileById(int userId)
        {
            var result = _profileService.GetProfileById(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("addProfile")]
        public IActionResult AddProfile(Profile profile)
        {
            var result = _profileService.AddProfile(profile);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }

}
