using BusinessLayer.Abstract;
using CoreLayer.Entities.Concerete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportBuddyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost("AddMessage")]
        public IActionResult AddMessage(Message message)
        {
            var result = _messageService.AddMessage(message);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetListMessagesByActivityId")]
        public IActionResult GetListMessagesByActivityId(int activityId)
        {
            var result = _messageService.GetListByActivityId(activityId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetListMessagesByUserId")]
        public IActionResult GetListMessagesByUserId(int userId)
        {
            var result = _messageService.GetListByUserId(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("updateMessage")]
        public IActionResult UpdateProduct(Message message)
        {
            var result = _messageService.Update(message);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpDelete("deleteMessage")]

        public IActionResult DeleteMessage(int id)
        {
            var result = _messageService.Delete(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getAllMessage")]
        public IActionResult GetList()
        {
            var result = _messageService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
