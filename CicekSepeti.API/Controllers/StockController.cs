using CicekSepeti.Application.Stock.Commands;
using CicekSepeti.Application.Stock.Queries;
using CicekSepeti.Application.Stock.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<List<CicekSepeti.Core.Entities.Stock>> Get()
        {
            return await _mediator.Send(new GetAllStockQuery());
        }

        [HttpPost("CreateStock")]
        public async Task<ActionResult<StockResponse>> CreateStock([FromBody] CreateStockCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
