using Microsoft.AspNetCore.Mvc;
using OC.Application.Interfaces.Commands;
using OC.Contracts.Requests;

namespace OC.Messaging.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserCommand _createUserCommand;

        public UserController(
            ICreateUserCommand createUserCommand
        )
        {
            _createUserCommand = createUserCommand;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(UserRequest request)
        {
            var result = await _createUserCommand.Execute(request);

            return result.Success ? Ok(result.GetValue()) : BadRequest(result.Error);
        }        
        
        [HttpPost("link")]
        public async Task<IActionResult> LinkUsersTypeChannel(UserRequest request)
        {
            var result = await _createUserCommand.Execute(request);

            return result.Success ? Ok(result.GetValue()) : BadRequest(result.Error);
        }
    }
}
