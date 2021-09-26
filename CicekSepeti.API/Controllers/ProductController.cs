using CicekSepeti.Application.Product.Commands;
using CicekSepeti.Application.Product.Queries;
using CicekSepeti.Application.Product.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<List<CicekSepeti.Core.Entities.Product>> Get()
        {
            return await _mediator.Send(new GetAllProductQuery());
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
