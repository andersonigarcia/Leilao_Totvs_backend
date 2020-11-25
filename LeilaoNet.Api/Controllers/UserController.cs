using LeilaoNet.Application.Clients.Commands;
using LeilaoNet.Application.Usuarios.Queries;
using LeilaoNet.Application.Usuarios.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeilaoNet.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Authenticate([FromQuery] string username, [FromQuery] string password)
        {
            var command = new LoginQuery { Username = username, Password = password };

            var user = await _mediator.Send(command);

            if (user == null)
                return Ok(new { message = "Usuário ou senha inválidos" });

            return Ok(user);
        }

        [HttpPost("logout")]
        public async Task<ActionResult<LogoutResponse>> NoAuthenticate([FromQuery] string username)
        {
            var command = new LogoutQuery { Username = username };

            var user = await _mediator.Send(command);                        

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(UsuarioCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(UsuarioUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(UsuarioDeleteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
