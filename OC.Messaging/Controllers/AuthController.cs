using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OC.Application.Interfaces.Commands;
using OC.Contracts.Requests;

namespace OC.Messaging.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthCommand _authCommand;

        public AuthController(IAuthCommand authCommand)
        {
            _authCommand = authCommand;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(AuthRequest request)
        {
            var result = await _authCommand.Execute(request);

            return result.Success ? Ok(result.GetValue()) : BadRequest(result.Error);
        }
    }
}