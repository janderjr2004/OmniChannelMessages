using Microsoft.AspNetCore.Mvc;
using OC.Application.Interfaces.Commands;
using OC.Contracts.Requests;

namespace OC.Messaging.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ISendMessageCommand _sendMessageCommand;

        public MessageController(ISendMessageCommand sendMessageCommand)
        {
            _sendMessageCommand = sendMessageCommand;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage(SendMessageRequest request)
        {
            var result = await _sendMessageCommand.Execute(request);

            return result.Success ? Ok(result.GetValue()) : BadRequest(result.Error);
        }
    }
}