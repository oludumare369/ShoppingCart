using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Dtos;
using ShoppingCart.Application.Features.ShoppingCart.Queries;
using System.Net;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("ShoppingCart-ById/{**Id}")]
        [HttpGet]
        [ProducesResponseType(typeof(ShoppingCartDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartDto>> GetBasketByIdAsync(string Id)
        {
            var shoppingCartQuery = new GetShoppingCartByIdQuery(Id);
            ShoppingCartDto shoppingCart = await _mediator.Send(shoppingCartQuery);

            return Ok(shoppingCart);
        }

        [Route("ShoppingCart-Update")]
        [HttpPut]
        [ProducesResponseType(typeof(ShoppingCartDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateBasketAsync([FromBody] UpdateShoppingCartDto shoppingCart)
        {
            await _mediator.Send(shoppingCart);

            return NoContent();
        }

        [Route("ShoppingCart-Delete")]
        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteBasketAsync([FromBody] DeleteShoppingCartDto shoppingCart)
        {
            await _mediator.Send(shoppingCart);

            return NoContent();
        }
    }
}
