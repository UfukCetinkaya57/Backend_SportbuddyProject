using BusinessLayer.Abstract;
using CoreLayer.Entities.Concerete;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportBuddyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinTheActivityController : ControllerBase
    {
        private IJoinTheActivityService _joinTheActivityService;
        public JoinTheActivityController(IJoinTheActivityService joinTheActivityService)
        {
            _joinTheActivityService = joinTheActivityService;
        }
        [HttpPost("AddJoinTheActivity")]
        public IActionResult AddJoinTheActivity(JoinTheActivity joinTheActivity)
        {
            var result = _joinTheActivityService.AddJoinTheActivity(joinTheActivity);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(JoinTheActivity joinTheActivity)
        {
            var result = _joinTheActivityService.Update(joinTheActivity);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _joinTheActivityService.Delete(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
