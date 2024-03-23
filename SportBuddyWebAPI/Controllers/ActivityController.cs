using BusinessLayer.Abstract;
using CoreLayer.Entities.Concerete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportBuddyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        [HttpPost("AddActivity")]
        public IActionResult AddActivity(Activity activity)
        {
            var result = _activityService.AddActivity(activity);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getActivityById")]
        public IActionResult GetActivityById(int userId)
        {
            var result = _activityService.GetActivityById(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        
        [HttpGet("getAllActivities")]
        public IActionResult GetAllActivities()
        {
            var result = _activityService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        
    }
}
