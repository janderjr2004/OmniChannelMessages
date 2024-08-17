using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OC.Application.Interfaces.Commands;
using OC.Contracts.Requests;

namespace OC.Messaging.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserCommand _createUserCommand;
        private readonly ILinkUserTypeChannelCommand _linkUserTypeChannelCommand;

        public UserController(
            ICreateUserCommand createUserCommand, 
            ILinkUserTypeChannelCommand linkUserTypeChannelCommand
        )
        {
            _createUserCommand = createUserCommand;
            _linkUserTypeChannelCommand = linkUserTypeChannelCommand;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(UserRequest request)
        {
            var result = await _createUserCommand.Execute(request);

            return result.Success ? Ok(result.GetValue()) : BadRequest(result.Error);
        }        
        
        [HttpPost("link")]
        public async Task<IActionResult> LinkUsersTypeChannel(LinkUserRequest request)
        {
            var result = await _linkUserTypeChannelCommand.Execute(request.UserId, request.TypeChannelIds);

            return result.Success ? Ok(result.GetValue()) : BadRequest(result.Error);
        }
    }
}
