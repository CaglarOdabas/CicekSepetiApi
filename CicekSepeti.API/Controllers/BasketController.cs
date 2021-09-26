using CicekSepeti.Application.Basket.Commands;
using CicekSepeti.Application.Basket.Queries;
using CicekSepeti.Application.Basket.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<List<Core.Entities.Basket>> Get()
        {
            return await _mediator.Send(new GetAllBasketQuery());
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<BasketResponse>> AddProduct([FromBody] CreateBasketCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
