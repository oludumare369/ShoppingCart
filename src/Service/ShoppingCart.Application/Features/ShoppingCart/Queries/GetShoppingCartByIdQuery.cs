using MediatR;
using ShoppingCart.Application.Dtos;

namespace ShoppingCart.Application.Features.ShoppingCart.Queries
{
    public class GetShoppingCartByIdQuery : IRequest<ShoppingCartDto>
    {
        public string Id { get; set; }

        public GetShoppingCartByIdQuery(string id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
