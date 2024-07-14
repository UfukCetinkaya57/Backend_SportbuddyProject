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
        public IActionResult AddActivity(Activity activity, int userId)
        {
            var result = _activityService.AddActivity(activity, userId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("JoinTheActivity")]
        public IActionResult JoinTheActivity(int activityId, int userId)
        {
            var result = _activityService.JoinTheActivity(activityId, userId);
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
        [HttpDelete("DeleteActivity")]
        public IActionResult DeleteActivity(int activityId)
        {
            var result = _activityService.DeleteActivity(activityId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
