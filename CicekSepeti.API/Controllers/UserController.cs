using CicekSepeti.Application.User.Commands;
using CicekSepeti.Application.User.Queries;
using CicekSepeti.Application.User.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<List<CicekSepeti.Core.Entities.User>> Get()
        {
            return await _mediator.Send(new GetAllUserQuery());
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserResponse>> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
